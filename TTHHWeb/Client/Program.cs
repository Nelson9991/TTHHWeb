using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TTHHWeb.Client;
using TTHHWeb.Client.Auth;
using TTHHWeb.Shared.Data.Repository;
using TTHHWeb.Shared.Data.Repository.IRepository;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(
  sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }
);

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AppAuthProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
  sp => sp.GetRequiredService<AppAuthProvider>()
);
builder.Services.AddScoped<ILoginService>(sp => sp.GetRequiredService<AppAuthProvider>());

builder.Services.AddScoped<IHttpRepository, HttpRepository>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
