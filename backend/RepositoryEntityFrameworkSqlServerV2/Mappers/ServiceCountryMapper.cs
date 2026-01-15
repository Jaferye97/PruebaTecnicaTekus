namespace RepositoryEntityFrameworkSqlServerV2.Mappers;

internal static class ServiceCountryMapper
{
    public static ServiceCountryModel ToDomain(this ServiceCountryEntity entity) => new ServiceCountryModel
    {
        Id = entity.Id,
        CountryId = entity.CountryId,
        ServiceId = entity.ServiceId,
    };

    public static ServiceCountryEntity ToEntity(this ServiceCountryModel domain) => new ServiceCountryEntity
    {
        Id = domain.Id,
        CountryId = domain.CountryId,
        ServiceId = domain.ServiceId,
    };
}
