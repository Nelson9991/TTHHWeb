using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTHHWeb.Shared.Models.CuentaContable;
using TTHHWeb.Shared.Data.Repository.IRepository;

namespace TTHHWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CuentaContableController : ControllerBase
{
  private readonly IHttpRepository httpRepository;

  public CuentaContableController(IHttpRepository httpRepository)
  {
    this.httpRepository = httpRepository;
  }

  [HttpGet("{sucursal:int}")]
  public async Task<IActionResult> Get(int sucursal)
  {
    var result = await httpRepository.GetFromJsonAsync<List<CuentaContableDto>>(
      $"Varios/Gestion_Cuenta_Contable_Nomina_Select?Sucursal={sucursal}"
    );
    return Ok(result.Response);
  }

  // POST: Varios/GestionContableNominaInsert?Sucursal=2&CodigoConceptoNomina=4&CodigoCategoOcupacional=4&CodigoOperacion=hola&CodigoCuenta=3&CodigoTipocuenta=sf
  [HttpPost("crear")]
  public async Task<IActionResult> Post(UpsertCuentaContableDto upsertCuentaContableDto)
  {
    var result = await httpRepository.PostAsJson<string, string>(
      $"Varios/GestionContableNominaInsert?Sucursal={upsertCuentaContableDto.Sucursal}&CodigoConceptoNomina={upsertCuentaContableDto.CodigoConceptoNomina}&CodigoCategoOcupacional={upsertCuentaContableDto.CodigoCategoriaocupacional}&CodigoOperacion={upsertCuentaContableDto.CodigoOperacion}&CodigoCuenta={upsertCuentaContableDto.CodigoCuentaContable}&CodigoTipocuenta={upsertCuentaContableDto.CodigoTipoCuenta}",
      ""
    );
    return Ok(result.Response);
  }

  // POST: Varios/GestionContableNominaDelete?Sucursal=2&CodigoConceptoNomina=2&CodigoCategoOcupacional=2&CodigoOperacion=ad&CodigoCuenta=2&CodigoTipocuenta=df
  [HttpPost("eliminar")]
  public async Task<IActionResult> Delete(UpsertCuentaContableDto upsertCuentaContableDto)
  {
    var result = await httpRepository.PostAsJson<string, string>(
      $"Varios/GestionContableNominaDelete?Sucursal={upsertCuentaContableDto.Sucursal}&CodigoConceptoNomina={upsertCuentaContableDto.CodigoConceptoNomina}&CodigoCategoOcupacional={upsertCuentaContableDto.CodigoCategoriaocupacional}&CodigoOperacion={upsertCuentaContableDto.CodigoOperacion}&CodigoCuenta={upsertCuentaContableDto.CodigoCuentaContable}&CodigoTipocuenta={upsertCuentaContableDto.CodigoTipoCuenta}",
      ""
    );
    return Ok(result.Response);
  }
}
