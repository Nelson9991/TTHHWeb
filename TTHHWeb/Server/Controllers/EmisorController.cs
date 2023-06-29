using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MudBlazor;
using TTHHWeb.Shared.Data.Repository;
using TTHHWeb.Shared.Data.Repository.IRepository;
using TTHHWeb.Shared.Models.Emisor;

namespace TTHHWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmisorController : ControllerBase
{
    private readonly IHttpRepository _httpRepository;

    public EmisorController(IHttpRepository httpRepository)
    {
        _httpRepository = httpRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<EmisorResponse>>> Get()
    {
        var httpResp = await _httpRepository.GetFromJsonAsync<List<EmisorResponse>>(
            "Varios/GetEmisor"
        );
        if (httpResp.Error || httpResp.Response is null)
        {
            return BadRequest("Ocurrió un error al cargar los códigos de las compañias.");
        }

        return httpResp.Response;
    }
}
