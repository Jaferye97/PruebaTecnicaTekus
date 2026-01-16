using Microsoft.EntityFrameworkCore;
using RepositoryEntityFrameworkSqlServer.Context;

namespace WebApi.Extensions.DependencyInjection;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EntityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConexionDb")));

        return services;
    }
}
