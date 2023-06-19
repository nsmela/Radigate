global using Radigate.Shared;
global using Microsoft.EntityFrameworkCore;
global using Radigate.Server.Services.PatientService;
global using Radigate.Server.Users.Services;
using Radigate.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Radigate.Server.Services.TaskService;
using Radigate.Server.Users.Data;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true); //https://stackoverflow.com/questions/72060349/form-field-is-required-even-if-not-defined-so
builder.Services.AddRazorPages();

//packages
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom services Dependancy Injection
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// SQLLite
var connectionString = builder.Configuration.GetConnectionString("SQLLiteConnection");
builder.Services.AddDbContextFactory<PatientDataContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContextFactory<UsersContext>(options => options.UseSqlite(connectionString));

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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
