using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTHHWeb.Shared.Models.Trabajador;

public class UpsertTrabajadorDto : ITrabajadorDto
{
  public int? COMP_Codigo { get; set; } = 0;
  public int? Id_Trabajador { get; set; } = 0;
  public string? Tipo_trabajador { get; set; } = "";
  public string? Apellido_Paterno { get; set; } = "";
  public string? Apellido_Materno { get; set; } = "";
  public string? Nombres { get; set; } = "";
  public string? Identificacion { get; set; } = "";
  public string? Entidad_Bancaria { get; set; } = "";
  public string? CarnetIESS { get; set; } = "";
  public string? Direccion { get; set; } = "";
  public string? Telefono_Fijo { get; set; } = "";
  public string? Telefono_Movil { get; set; } = "";
  public string? Genero { get; set; } = "";
  public string? Nro_Cuenta_Bancaria { get; set; } = "";
  public string? Codigo_Categoria_Ocupacion { get; set; } = "";
  public string? Ocupacion { get; set; } = "";
  public string? Centro_Costos { get; set; } = "";
  public string? Nivel_Salarial { get; set; } = "";
  public string? EstadoTrabajador { get; set; } = "";
  public string? Tipo_Contrato { get; set; } = "";
  public string? Tipo_Cese { get; set; } = "";
  public string? EstadoCivil { get; set; } = "";
  public string? TipodeComision { get; set; } = "";
  public DateTime? FechaNacimiento { get; set; } = DateTime.Now;
  public DateTime? FechaIngreso { get; set; } = DateTime.Now;
  public DateTime? FechaCese { get; set; } = DateTime.Now;
  public int? PeriododeVacaciones { get; set; } = 0;
  public DateTime? FechaReingreso { get; set; } = DateTime.Now;
  public DateTime? Fecha_Ult_Actualizacion { get; set; } = DateTime.Now;
  public string? EsReingreso { get; set; } = "";
  public object? BancoCTA_CTE { get; set; } = "";
  public string? Tipo_Cuenta { get; set; } = "";
  public int? RSV_Indem_Acumul { get; set; } = 0;
  public int? Ao_Ult_Rsva_Indemni { get; set; } = 0;
  public int? Mes_Ult_Rsva_Indemni { get; set; } = 0;
  public int? FormaCalculo13ro { get; set; } = 0;
  public int? FormaCalculo14ro { get; set; } = 0;
  public int? BoniComplementaria { get; set; } = 0;
  public int? BoniEspecial { get; set; } = 0;
  public int? Remuneracion_Minima { get; set; } = 0;
  public int? CuotaCuentaCorriente { get; set; } = 0;
  public string? Fondo_Reserva { get; set; } = "";
  public string? Mensaje { get; set; } = "";
}
