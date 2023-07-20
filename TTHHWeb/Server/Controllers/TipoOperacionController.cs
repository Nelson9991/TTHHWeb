using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTHHWeb.Shared.Data.Repository.IRepository;
using TTHHWeb.Shared.Models.CentroCosto;
using TTHHWeb.Shared.Models.TipoOperacion;

namespace TTHHWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoOperacionController : ControllerBase
{
  private readonly IHttpRepository _httpRepository;

  public TipoOperacionController(IHttpRepository httpRepository)
  {
    _httpRepository = httpRepository;
  }

  [HttpGet]
  public async Task<ActionResult<List<TipoOperacionDto>>> Get()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<TipoOperacionDto>>(
      "Varios/TipoOperacion"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }
}
