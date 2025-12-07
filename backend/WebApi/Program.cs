using System.Text;
using Application.Ports.CountriesApiClient;
using Application.Ports.Dependencies;
using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Application.Services;
using Application.Services.Implementations;
using Application.UseCases.Authentication.Implementations;
using Application.UseCases.Country;
using Application.UseCases.Country.Implementations;
using Application.UseCases.Service;
using Application.UseCases.Service.Implementations;
using Application.UseCases.ServiceCountry;
using Application.UseCases.ServiceCountry.Implementations;
using Application.UseCases.Supplier;
using Application.UseCases.Supplier.Implementations;
using Application.UseCases.SupplierAttribute;
using Application.UseCases.SupplierAttribute.Implementations;
using CountriesApiClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Repositories;
using RepositoryEntityFrameworkSqlServer.Repositories.Implementations;
using TokenService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Conexion Bd
builder.Services.AddDbContext<EntityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDb")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Define esquema JWT (Bearer)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token en este formato: Bearer {token}"
    });

    // Requerir token por defecto (excepto endpoints AllowAnonymous)
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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
builder.Services.AddScoped<IGetServiceByFiltersUseCase, GetServiceByFiltersUseCase>();

// ServiceCountry
builder.Services.AddScoped<IDeleteServiceCountryByIdUseCase, DeleteServiceCountryByIdUseCase>();
builder.Services.AddScoped<IAddServiceCountryUseCase, AddServiceCountryUseCase>();

// Port - Repository
builder.Services.AddScoped<ISupplierRepositoryPort, SupplierRepository>();
builder.Services.AddScoped<ISupplierAttributeRepositoryPort, SupplierAttributeRepository>();
builder.Services.AddScoped<IServiceRepositoryPort, ServiceRepository>();
builder.Services.AddScoped<IServiceCountryRepository, ServiceCountryRepository>();
builder.Services.AddScoped<IServiceCountryRepositoryPort, ServiceCountryRepository>();

// Repository
builder.Services.AddScoped<ISupplierAttributeRepository, SupplierAttributeRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

// JWT
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();
builder.Services.AddSingleton<IJwtService, JwtService>();
builder.Services.AddTransient<AuthenticationUserUseCase>();

// Authentication
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
        )
    };
});

// Cache
builder.Services.AddScoped<ICountriesService, CachedCountriesService>();
builder.Services.AddScoped<ICountriesApiClientPort, CountriesApiClientService>();

builder.Services.AddMemoryCache();

builder.Services.AddHttpClient<ICountriesApiClientPort, CountriesApiClientService>(client =>
{
    client.BaseAddress = new Uri("https://restcountries.com/v3.1/all?fields=cca2,cca3,name");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
