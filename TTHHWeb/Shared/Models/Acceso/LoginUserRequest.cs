namespace TTHHWeb.Shared.Models.Acceso;

public class LoginUserRequest
{
    public string CodigoUsuario { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string CodigoCompañia { get; set; } = string.Empty;
}
