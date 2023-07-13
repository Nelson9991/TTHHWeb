using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTHHWeb.Shared.Models.CentroCosto;

public class CentroCostoDto : ICentroCostoDto
{
  [Required(ErrorMessage = "El Código es requerido")]
  public int Codigo { get; set; }

  [Required(ErrorMessage = "El Nombre es requerido")]
  public string NombreCentroCostos { get; set; } = string.Empty;
  public string Mensaje { get; set; } = string.Empty;
}
