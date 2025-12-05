using Domain.Models.Country;
using RepositoryEntityFrameworkSqlServer.Entities;

namespace RepositoryEntityFrameworkSqlServer.Mappers
{
    internal static class CountryMapper
    {
        public static CountryModel ToDomain(this CountryEntity entity) => new CountryModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Code = entity.Code,
        };

        public static CountryEntity ToEntity(this CountryModel domain) => new CountryEntity
        {
            Id = domain.Id,
            Name = domain.Name,
            Code = domain.Code,
        };
    }
}
