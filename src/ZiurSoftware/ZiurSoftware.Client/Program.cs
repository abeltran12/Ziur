using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ZiurSoftware.Client;
using ZiurSoftware.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddScoped<AuthTokenHandler>();

builder.Services.AddHttpClient("ZiurApi", client =>
{
    client.BaseAddress = new Uri("https://mainserver.ziursoftware.com/Ziur.API/basedatos_01/ZiurServiceRest.svc/api/");
})
.AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ZiurApi"));

await builder.Build().RunAsync();
