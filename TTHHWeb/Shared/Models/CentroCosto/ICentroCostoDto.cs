using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTHHWeb.Shared.Models.CentroCosto;

public interface ICentroCostoDto
{
  public int Codigo { get; set; }
  public string NombreCentroCostos { get; set; }
}
