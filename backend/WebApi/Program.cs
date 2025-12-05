using Application.Ports.RepositoryEntityFrameworkSqlServer;
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

builder.Services.AddScoped<IAddSupplierUseCase, AddSupplierUseCase>();
builder.Services.AddScoped<IGetSupplierByIdUseCase, GetSupplierByIdUseCase>();
builder.Services.AddScoped<IUpdateSupplierUseCase, UpdateSupplierUseCase>();
builder.Services.AddScoped<IGetSupplierByFiltersUseCase, GetSupplierByFiltersUseCase>();

builder.Services.AddScoped<IDeleteSupplierAttributeByIdUseCase, DeleteSupplierAttributeByIdUseCase>();

builder.Services.AddScoped<ISupplierRepositoryPort, SupplierRepository>();
builder.Services.AddScoped<ISupplierAttributeRepositoryPort, SupplierAttributeRepository>();

builder.Services.AddScoped<ISupplierAttributeRepository, SupplierAttributeRepository>();

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
