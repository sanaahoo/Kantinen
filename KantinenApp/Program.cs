using Core.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KantinenApp;
using Blazored.LocalStorage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IEventServices, EventServices>();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.AddBlazoredLocalStorage(); // Register the service
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthService>(); // Add AuthService to DI container

builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();