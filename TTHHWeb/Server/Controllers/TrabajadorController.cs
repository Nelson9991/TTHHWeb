using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTHHWeb.Shared.Data.Repository.IRepository;
using TTHHWeb.Shared.Models.CentroCosto;
using TTHHWeb.Shared.Models.Trabajador;

namespace TTHHWeb.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrabajadorController : ControllerBase
{
  private readonly IHttpRepository _httpRepository;

  public TrabajadorController(IHttpRepository httpRepository)
  {
    _httpRepository = httpRepository;
  }

  [HttpGet("{sucursalId}")]
  public async Task<ActionResult<List<TrabajadorDto>>> Get(string sucursalId)
  {
    var response = await _httpRepository.GetFromJsonAsync<List<TrabajadorDto>>(
      $"Varios/TrabajadorSelect?sucursal={sucursalId}"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("tipos")]
  public async Task<ActionResult<List<TipoTrabajadorDto>>> GetTipos()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<TipoTrabajadorDto>>(
      $"Varios/TipoTrabajador"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("generos")]
  public async Task<ActionResult<List<GenerodDto>>> GetGeneros()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<GenerodDto>>($"Varios/Genero");

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("estados")]
  public async Task<ActionResult<List<EstadoTrabajadorDto>>> GetEstados()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<EstadoTrabajadorDto>>(
      $"Varios/EstadoTrabajador"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("periodoVacaciones")]
  public async Task<ActionResult<List<PeriodoVacacionesDto>>> GetPeriodoVacaciones()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<PeriodoVacacionesDto>>(
      $"Varios/PeriodoVacaciones"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("tiposComision")]
  public async Task<ActionResult<List<TipoComisionDto>>> GetTiposComision()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<TipoComisionDto>>(
      $"Varios/TipoComision"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("decimos")]
  public async Task<ActionResult<List<DecimoTerceroDecimoCuartoDto>>> GetDecimos()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<DecimoTerceroDecimoCuartoDto>>(
      $"Varios/DecimoTerceroDecimoCuarto"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpGet("fondosReserva")]
  public async Task<ActionResult<List<FondoReservaDto>>> GetFondosReserva()
  {
    var response = await _httpRepository.GetFromJsonAsync<List<FondoReservaDto>>(
      $"Varios/FondoReserva"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al cargar los datos");
    }

    return response.Response!;
  }

  [HttpPost("crear")]
  public async Task<IActionResult> Create(UpsertTrabajadorDto upsertTrabajadorDto)
  {
    var response = await _httpRepository.PostAsJson<string, string>(
      $"Varios/TrabajadorInsert?COMP_Codigo={upsertTrabajadorDto.COMP_Codigo}&Tipo_trabajador={upsertTrabajadorDto.Tipo_trabajador}&Apellido_Paterno={upsertTrabajadorDto.Apellido_Paterno}&Apellido_Materno={upsertTrabajadorDto.Apellido_Materno}&Nombres={upsertTrabajadorDto.Nombres}&Identificacion={upsertTrabajadorDto.Identificacion}&Entidad_Bancaria={upsertTrabajadorDto.Entidad_Bancaria}&CarnetIESS={upsertTrabajadorDto.CarnetIESS}&Direccion={upsertTrabajadorDto.Direccion}&Telefono_Fijo={upsertTrabajadorDto.Telefono_Fijo}&Telefono_Movil={upsertTrabajadorDto.Telefono_Movil}&Genero={upsertTrabajadorDto.Genero}&Nro_Cuenta_Bancaria={upsertTrabajadorDto.Nro_Cuenta_Bancaria}&Codigo_Categoria_Ocupacion={upsertTrabajadorDto.Codigo_Categoria_Ocupacion}&Ocupacion={upsertTrabajadorDto.Ocupacion}&Centro_Costos={upsertTrabajadorDto.Centro_Costos}&Nivel_Salarial={upsertTrabajadorDto.Nivel_Salarial}&EstadoTrabajador={upsertTrabajadorDto.EstadoTrabajador}&Tipo_Contrato={upsertTrabajadorDto.Tipo_Contrato}&Tipo_Cese={upsertTrabajadorDto.Tipo_Cese}&EstadoCivil={upsertTrabajadorDto.EstadoCivil}&TipodeComision={upsertTrabajadorDto.TipodeComision}&FechaNacimiento={upsertTrabajadorDto.FechaNacimiento.Value.ToString("MM/dd/yyyy")}&FechaIngreso={upsertTrabajadorDto.FechaIngreso.Value.ToString("MM/dd/yyyy")}&FechaCese={upsertTrabajadorDto.FechaCese.Value.ToString("MM/dd/yyyy")}&PeriododeVacaciones={upsertTrabajadorDto.PeriododeVacaciones}&FechaReingreso={upsertTrabajadorDto.FechaReingreso.Value.ToString("MM/dd/yyyy")}&Fecha_Ult_Actualizacion={upsertTrabajadorDto.Fecha_Ult_Actualizacion.Value.ToString("MM/dd/yyyy")}&EsReingreso={upsertTrabajadorDto.EsReingreso}&Tipo_Cuenta={upsertTrabajadorDto.Tipo_Cuenta}&FormaCalculo13ro={upsertTrabajadorDto.FormaCalculo13ro}&FormaCalculo14ro={upsertTrabajadorDto.FormaCalculo14ro}&BoniComplementaria={upsertTrabajadorDto.BoniComplementaria}&BoniEspecial={upsertTrabajadorDto.BoniEspecial}&Remuneracion_Minima={upsertTrabajadorDto.Remuneracion_Minima}&Fondo_Reserva={upsertTrabajadorDto.Fondo_Reserva}",
      ""
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al agregar un trabajador");
    }

    return Ok(response.Response);
  }

  [HttpPut("editar")]
  public async Task<IActionResult> Edit(UpsertTrabajadorDto upsertTrabajadorDto)
  {
    var response = await _httpRepository.PostAsJson<string, UpsertTrabajadorDto>(
      $"Varios/TrabajadorUpdate?COMP_Codigo={upsertTrabajadorDto.COMP_Codigo}&Tipo_trabajador={upsertTrabajadorDto.Tipo_trabajador}&Apellido_Paterno={upsertTrabajadorDto.Apellido_Paterno}&Apellido_Materno={upsertTrabajadorDto.Apellido_Materno}&Nombres={upsertTrabajadorDto.Nombres}&Identificacion={upsertTrabajadorDto.Identificacion}&Entidad_Bancaria={upsertTrabajadorDto.Entidad_Bancaria}&CarnetIESS={upsertTrabajadorDto.CarnetIESS}&Direccion={upsertTrabajadorDto.Direccion}&Telefono_Fijo={upsertTrabajadorDto.Telefono_Fijo}&Telefono_Movil={upsertTrabajadorDto.Telefono_Movil}&Genero={upsertTrabajadorDto.Genero}&Nro_Cuenta_Bancaria={upsertTrabajadorDto.Nro_Cuenta_Bancaria}&Codigo_Categoria_Ocupacion={upsertTrabajadorDto.Codigo_Categoria_Ocupacion}&Ocupacion={upsertTrabajadorDto.Ocupacion}&Centro_Costos={upsertTrabajadorDto.Centro_Costos}&Nivel_Salarial={upsertTrabajadorDto.Nivel_Salarial}&EstadoTrabajador={upsertTrabajadorDto.EstadoTrabajador}&Tipo_Contrato={upsertTrabajadorDto.Tipo_Contrato}&Tipo_Cese={upsertTrabajadorDto.Tipo_Cese}&EstadoCivil={upsertTrabajadorDto.EstadoCivil}&TipodeComision={upsertTrabajadorDto.TipodeComision}&FechaNacimiento={upsertTrabajadorDto.FechaNacimiento.Value.ToString("MM/dd/yyyy")}&FechaIngreso={upsertTrabajadorDto.FechaIngreso.Value.ToString("MM/dd/yyyy")}&FechaCese={upsertTrabajadorDto.FechaCese.Value.ToString("MM/dd/yyyy")}&PeriododeVacaciones={upsertTrabajadorDto.PeriododeVacaciones}&FechaReingreso={upsertTrabajadorDto.FechaReingreso.Value.ToString("MM/dd/yyyy")}&Fecha_Ult_Actualizacion={upsertTrabajadorDto.Fecha_Ult_Actualizacion.Value.ToString("MM/dd/yyyy")}&EsReingreso={upsertTrabajadorDto.EsReingreso}&Tipo_Cuenta={upsertTrabajadorDto.Tipo_Cuenta}&FormaCalculo13ro={upsertTrabajadorDto.FormaCalculo13ro}&FormaCalculo14ro={upsertTrabajadorDto.FormaCalculo14ro}&BoniComplementaria={upsertTrabajadorDto.BoniComplementaria}&BoniEspecial={upsertTrabajadorDto.BoniEspecial}&Remuneracion_Minima={upsertTrabajadorDto.Remuneracion_Minima}&Fondo_Reserva={upsertTrabajadorDto.Fondo_Reserva}",
      ""
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al editar un trabajador");
    }

    return Ok("Actualización Exitosa");
  }

  [HttpDelete("eliminar/{sucursal}/{codigoempleado}")]
  public async Task<IActionResult> Delete(int sucursal, int codigoempleado)
  {
    var response = await _httpRepository.Get(
      $"Varios/TrabajadorDelete?sucursal={sucursal}&codigoempleado={codigoempleado}"
    );

    if (response.Error)
    {
      return BadRequest("Ocurrió un error al eliminar un trabajador");
    }

    return Ok("Eliminación Exitosa!");
  }
}
