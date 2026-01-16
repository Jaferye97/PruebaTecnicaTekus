using Application.Ports.CountriesApiClient;
using Application.Services.Implementations;
using Application.Services;
using CountriesApiClient;

namespace WebApi.Extensions.DependencyInjection;

public static class CacheExtensions
{
    public static IServiceCollection AddCacheServices(this IServiceCollection services)
    {
        services.AddMemoryCache();

        services.AddScoped<ICountriesService, CachedCountriesService>();

        services.AddHttpClient<ICountriesApiClientPort, CountriesApiClientService>(client =>
        {
            client.BaseAddress = new Uri(
                "https://restcountries.com/v3.1/all?fields=cca2,cca3,name");
        });

        return services;
    }
}
