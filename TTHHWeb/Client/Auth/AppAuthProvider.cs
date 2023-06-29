using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using TTHHWeb.Client.Helpers;
using TTHHWeb.Shared.Models.Acceso;

namespace TTHHWeb.Client.Auth;

public class AppAuthProvider : AuthenticationStateProvider, ILoginService
{
  private readonly IJSRuntime _js;
  private AuthenticationState _anonymous =>
    new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

  public AppAuthProvider(IJSRuntime js)
  {
    _js = js;
  }

  public static readonly string TokenKey = "token";

  public override async Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    var token = await _js.ObtenerDeLocalStorage(TokenKey);
    if (token is null)
    {
      return _anonymous;
    }

    return ConstruirAuthState(token.ToString()!);
  }

  private AuthenticationState ConstruirAuthState(string token)
  {
    var userInfo = JsonSerializer.Deserialize<LoginUserResponse>(
      token,
      new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    );

    var claims = new[]
    {
      new Claim(ClaimTypes.Name, userInfo.NOMBREUSUARIO),
      new Claim(ClaimTypes.Role, userInfo.PERFIL),
      new Claim(ClaimTypes.NameIdentifier, userInfo.CODIGOPERFIL.ToString()),
      new Claim("NombreCompañia", userInfo.NOMBRECOMPANIA),
      new Claim("CodigoCompañia", userInfo.COMPANIA.ToString()),
      new Claim("RucUsuario", userInfo.RucUsuario.ToString()),
      new Claim("Estado", userInfo.ESTADO),
    };
    var identity = new ClaimsIdentity(claims, "apiauth_type");
    var user = new ClaimsPrincipal(identity);
    return new AuthenticationState(user);
  }

  public async Task Login(string token)
  {
    await _js.GuardarEnLocalStorage(TokenKey, token);
    var authState = ConstruirAuthState(token);
    NotifyAuthenticationStateChanged(Task.FromResult(authState));
  }

  public async Task Logout()
  {
    await _js.RemoverDelLocalStorage(TokenKey);
    NotifyAuthenticationStateChanged(Task.FromResult(_anonymous));
  }
}
