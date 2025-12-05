using Domain.Models.Service;
using RepositoryEntityFrameworkSqlServer.Entities;

namespace RepositoryEntityFrameworkSqlServer.Mappers
{
    internal static class ServiceMapper
    {
        public static ServiceModel ToDomain(this ServiceEntity entity) => new ServiceModel
        {
            Id = entity.Id,
            Name = entity.Name,
            HourlyRate = entity.HourlyRate,
            SupplierId = entity.SupplierId,
        };

        public static ServiceEntity ToEntity(this ServiceModel domain) => new ServiceEntity
        {
            Id = domain.Id,
            Name = domain.Name,
            HourlyRate = domain.HourlyRate,
            SupplierId = domain.SupplierId,
        };
    }
}
