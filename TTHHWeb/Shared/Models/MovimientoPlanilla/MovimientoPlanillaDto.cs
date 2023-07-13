using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTHHWeb.Shared.Models.MovimientoPlanilla;

public class MovimientoPlanillaDto : IMovimientoPlanilla
{
  public int CodigoConcepto { get; set; }
  public string Concepto { get; set; } = string.Empty;
  public int Prioridad { get; set; }
  public string TipoOperacion { get; set; } = string.Empty;
  public string Cuenta1 { get; set; } = string.Empty;
  public string Cuenta2 { get; set; } = string.Empty;
  public string Cuenta3 { get; set; } = string.Empty;
  public string Cuenta4 { get; set; } = string.Empty;
  public string MovimientoExcepcion1 { get; set; } = string.Empty;
  public string MovimientoExcepcion2 { get; set; } = string.Empty;
  public string MovimientoExcepcion3 { get; set; } = string.Empty;
  public string Aplica_iess { get; set; } = string.Empty;
  public string Aplica_imp_renta { get; set; } = string.Empty;
  public string Empresa_Afecta_Iess { get; set; } = string.Empty;
  public object Mensaje { get; set; } = string.Empty;
}
