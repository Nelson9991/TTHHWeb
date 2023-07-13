using Microsoft.AspNetCore.Mvc;
using TTHHWeb.Shared.Data.Repository.IRepository;
using TTHHWeb.Shared.Models.CentroCosto;

namespace TTHHWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CentroCostoController : ControllerBase
{
  private readonly IHttpRepository _httpRepository;

  public CentroCostoController(IHttpRepository httpRepository)
  {
    _httpRepository = httpRepository;
  }

  [HttpGet]
  public async Task<ActionResult<List<CentroCostoDto>>> Get()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<CentroCostoDto>>(
      "Varios/CentroCostosSelect"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpPost("crear")]
  public async Task<IActionResult> Create(UpsertCentroCostoDto upsertCentroCostoDto)
  {
    var response = await _httpRepository.PostAsJson<string, List<CentroCostoDto>>(
      $"Varios/CentroCostosInsert?codigocentrocostos={upsertCentroCostoDto.Codigo}&descripcioncentrocostos={upsertCentroCostoDto.NombreCentroCostos}",
      ""
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error agregar un centro de costo");
    }

    return Ok(response.Response[0]);
  }

  [HttpPut("editar")]
  public async Task<IActionResult> Edit(UpsertCentroCostoDto upsertCentroCostoDto)
  {
    var response = await _httpRepository.Get(
      $"Varios/CentroCostosUpdate?codigocentrocostos={upsertCentroCostoDto.Codigo}&descripcioncentrocostos={upsertCentroCostoDto.NombreCentroCostos}"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error editar un centro de costo");
    }

    return Ok("Actualización Exitosa");
  }

  [HttpDelete("eliminar/{codigo}")]
  public async Task<IActionResult> Delete(string codigo)
  {
    var response = await _httpRepository.Get(
      $"Varios/CentroCostosDelete?codigocentrocostos={codigo}&descripcioncentrocostos=qw"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error eliminar un centro de costo");
    }

    return Ok("Eliminación Exitosa!");
  }
}
