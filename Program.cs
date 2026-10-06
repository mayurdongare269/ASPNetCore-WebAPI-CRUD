using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyFirstApi.Data;
using MyFirstApi.Entities;
using MyFirstApi.IService;
using MyFirstApi.Services;
// using MyFirstApi.Services.EmployeeService;

var builder = WebApplication.CreateBuilder(args);

/// connect with sqlserver AND perform migrations..
builder.Services.AddDbContext<AppDbContext>
    (Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

///for services
/// to conncet both interfaceauthservice and authservice
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
