using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTHHWeb.Shared.Data.Repository.IRepository;
using TTHHWeb.Shared.Models.Acceso;

namespace TTHHWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
  private readonly IHttpRepository _httpRepository;

  public UsuarioController(IHttpRepository httpRepository)
  {
    _httpRepository = httpRepository;
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginUserRequest loginUserRequest)
  {
    var response = await _httpRepository.GetFromJsonAsync<List<LoginUserResponse>>(
      $"Usuarios?usuario={loginUserRequest.CodigoUsuario}&password={loginUserRequest.Password}"
    );

    if (response.Error || response.Response is null)
    {
      return BadRequest("Inicio de Sesión fallido!.");
    }

    return new JsonResult(response.Response);
  }
}
