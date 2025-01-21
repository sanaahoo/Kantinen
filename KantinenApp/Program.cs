using Core.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KantinenApp;
    

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IEventServices, EventServices>();
builder.Services.AddScoped<ILoginServices, LoginServices>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
