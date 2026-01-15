namespace RepositoryEntityFrameworkSqlServerV2.Mappers;

internal static class ServiceWithCountryMapper
{
    public static ServiceWithCountryModel ToDomain(ServiceEntity entity)
    {
        return new ServiceWithCountryModel
        {
            Id = entity.Id,
            Name = entity.Name,
            HourlyRate = entity.HourlyRate,
            SupplierId = entity.SupplierId,

            ServiceCountry = entity.ServiceCountry?
                .Select(sc => new ServiceCountryDetailModel
                {
                    Id = sc.Id,
                    ServiceId = sc.ServiceId,
                    CountryId = sc.CountryId,
                    Code = sc.Country?.Code,
                    Name = sc.Country?.Name
                }
                )
                .ToList() ?? new List<ServiceCountryDetailModel>()
        };
    }
}
