global using Radigate.Shared;
global using System.Net.Http.Json;
global using Radigate.Client.Services.PatientService;
global using Radigate.Client.Services.TaskService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radigate.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
