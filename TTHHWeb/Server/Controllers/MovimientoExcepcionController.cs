using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTHHWeb.Shared.Data.Repository.IRepository;
using TTHHWeb.Shared.Models.CentroCosto;
using TTHHWeb.Shared.Models.MovimientoExcepcion1y2;

namespace TTHHWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovimientoExcepcionController : ControllerBase
{
  private readonly IHttpRepository _httpRepository;

  public MovimientoExcepcionController(IHttpRepository httpRepository)
  {
    _httpRepository = httpRepository;
  }

  [HttpGet("1y2")]
  public async Task<ActionResult<List<MovimientoExcepcionDto>>> GetMov1y2()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<MovimientoExcepcionDto>>(
      "Varios/MovimientosExcepcion1y2"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("3")]
  public async Task<ActionResult<List<MovimientoExcepcionDto>>> GetMov3()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<MovimientoExcepcionDto>>(
      "Varios/MovimientosExcepcion3"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("afectaIess")]
  public async Task<ActionResult<List<MovimientoExcepcionDto>>> GetAfectaIess()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<MovimientoExcepcionDto>>(
      "Varios/TrabaAfectaIESS"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("afectaRenta")]
  public async Task<ActionResult<List<MovimientoExcepcionDto>>> GetAfectaImpuestoRenta()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<MovimientoExcepcionDto>>(
      "Varios/TrabAfecImpuestoRenta"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }
}
