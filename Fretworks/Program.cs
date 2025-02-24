using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fretworks;
using Fretworks.Config;
using MudBlazor.Services;
using PutridParrot.FretPositions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(_ => new Application());
builder.Services.AddScoped(_ => DefaultInstrumentSpecifications.Get());

builder.Services.AddMudServices();
builder.Services.AddMudBlazorDialog();

await builder.Build().RunAsync();
