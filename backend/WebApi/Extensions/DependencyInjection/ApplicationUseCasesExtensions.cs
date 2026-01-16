using Application.UseCases.Country.Implementations;
using Application.UseCases.Country;
using Application.UseCases.Service.Implementations;
using Application.UseCases.Service;
using Application.UseCases.ServiceCountry.Implementations;
using Application.UseCases.ServiceCountry;
using Application.UseCases.Supplier.Implementations;
using Application.UseCases.Supplier;
using Application.UseCases.SupplierAttribute.Implementations;
using Application.UseCases.SupplierAttribute;

namespace WebApi.Extensions.DependencyInjection;

public static class ApplicationUseCasesExtensions
{
    public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
    {
        // Country
        services.AddScoped<IGetCountryByNameUseCase, GetCountryByNameUseCase>();

        // Supplier
        services.AddScoped<IAddSupplierUseCase, AddSupplierUseCase>();
        services.AddScoped<IGetSupplierByIdUseCase, GetSupplierByIdUseCase>();
        services.AddScoped<IUpdateSupplierUseCase, UpdateSupplierUseCase>();
        services.AddScoped<IGetSupplierByFiltersUseCase, GetSupplierByFiltersUseCase>();

        // SupplierAttribute
        services.AddScoped<IDeleteSupplierAttributeByIdUseCase, DeleteSupplierAttributeByIdUseCase>();

        // Service
        services.AddScoped<IAddServiceWithCountryUseCase, AddServiceWithCountryUseCase>();
        services.AddScoped<IGetServiceByIdUseCase, GetServiceByIdUseCase>();
        services.AddScoped<IUpdateServiceUseCase, UpdateServiceUseCase>();
        services.AddScoped<IGetServiceByFiltersUseCase, GetServiceByFiltersUseCase>();

        // ServiceCountry
        services.AddScoped<IAddServiceCountryUseCase, AddServiceCountryUseCase>();
        services.AddScoped<IDeleteServiceCountryByIdUseCase, DeleteServiceCountryByIdUseCase>();

        return services;
    }
}
