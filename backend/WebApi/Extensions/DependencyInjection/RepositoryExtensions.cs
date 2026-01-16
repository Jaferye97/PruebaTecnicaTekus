using Application.Ports.RepositoryEntityFrameworkSqlServer;
using RepositoryEntityFrameworkSqlServer.Repositories.Implementations;
using RepositoryEntityFrameworkSqlServer.Repositories;

namespace WebApi.Extensions.DependencyInjection;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISupplierRepositoryPort, SupplierRepository>();
        services.AddScoped<ISupplierAttributeRepositoryPort, SupplierAttributeRepository>();
        services.AddScoped<IServiceRepositoryPort, ServiceRepository>();
        services.AddScoped<IServiceCountryRepositoryPort, ServiceCountryRepository>();

        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IServiceCountryRepository, ServiceCountryRepository>();
        services.AddScoped<ISupplierAttributeRepository, SupplierAttributeRepository>();

        return services;
    }
}
