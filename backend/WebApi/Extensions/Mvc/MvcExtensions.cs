using Microsoft.AspNetCore.Mvc.Authorization;

namespace WebApi.Extensions.Mvc;

public static class MvcExtensions
{
    public static IServiceCollection AddMvcWithAuthorization(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add(new AuthorizeFilter());
        });

        return services;
    }
}