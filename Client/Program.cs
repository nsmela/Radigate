global using Radigate.Shared;
global using System.Net.Http.Json;
global using Radigate.Client.Services.PatientService;
global using Radigate.Client.Services.TaskService;
global using Radigate.Client.Services.AuthService;
global using Radigate.Client.Data;
global using Radigate.Client.Data.TaskItems;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radigate.Client;
using MudBlazor.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
