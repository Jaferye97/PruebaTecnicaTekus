using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Application.UseCases.Service;
using Application.UseCases.Service.Implementations;
using Application.UseCases.Supplier;
using Application.UseCases.Supplier.Implementations;
using Application.UseCases.SupplierAttribute;
using Application.UseCases.SupplierAttribute.Implementations;
using Microsoft.EntityFrameworkCore;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Repositories;
using RepositoryEntityFrameworkSqlServer.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Conexion Bd
builder.Services.AddDbContext<EntityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDb")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Supplier
builder.Services.AddScoped<IAddSupplierUseCase, AddSupplierUseCase>();
builder.Services.AddScoped<IGetSupplierByIdUseCase, GetSupplierByIdUseCase>();
builder.Services.AddScoped<IUpdateSupplierUseCase, UpdateSupplierUseCase>();
builder.Services.AddScoped<IGetSupplierByFiltersUseCase, GetSupplierByFiltersUseCase>();

// SupplierAttribute
builder.Services.AddScoped<IDeleteSupplierAttributeByIdUseCase, DeleteSupplierAttributeByIdUseCase>();

// Service
builder.Services.AddScoped<IAddServiceWithCountryUseCase, AddServiceWithCountryUseCase>();
builder.Services.AddScoped<IGetServiceByIdUseCase, GetServiceByIdUseCase>();
builder.Services.AddScoped<IUpdateServiceUseCase, UpdateServiceUseCase>();

// Port - Repository
builder.Services.AddScoped<ISupplierRepositoryPort, SupplierRepository>();
builder.Services.AddScoped<ISupplierAttributeRepositoryPort, SupplierAttributeRepository>();
builder.Services.AddScoped<IServiceRepositoryPort, ServiceRepository>();
builder.Services.AddScoped<IServiceCountryRepository, ServiceCountryRepository>();

// Repository
builder.Services.AddScoped<ISupplierAttributeRepository, SupplierAttributeRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
