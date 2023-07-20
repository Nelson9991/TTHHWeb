using TTHHWeb.Shared.Models.CuentaContable;

namespace TTHHWeb.Shared.Models.CuentaContable;

public class CuentaContableDto : ICuentaContableDto
{
  public int Sucursal { get; set; }
  public int CodigoConceptoNomina { get; set; }
  public string DescripcionConcepto { get; set; }
  public int CodigoCategoriaocupacional { get; set; }
  public string DescripcionCategoria { get; set; }
  public string CodigoOperacion { get; set; }
  public double CodigoCuentaContable { get; set; }
  public string CodigoTipoCuenta { get; set; }
  public string DescripcionCuenta { get; set; }
  public string? Mensaje { get; set; }
}
