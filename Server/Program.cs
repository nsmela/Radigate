global using Radigate.Shared;
global using Microsoft.EntityFrameworkCore;
global using Radigate.Server.Services.PatientService;
using Radigate.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//packages
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom services Dependancy Injection
builder.Services.AddScoped<IPatientService, PatientService>();

// SQLLite
var connectionString = builder.Configuration.GetConnectionString("SQLLiteConnection");
builder.Services.AddDbContextFactory<PatientDataContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
}
else {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
