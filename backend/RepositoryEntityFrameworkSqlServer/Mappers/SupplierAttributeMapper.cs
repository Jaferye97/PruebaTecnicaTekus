using Domain.Models.Supplier;
using RepositoryEntityFrameworkSqlServer.Entities;

namespace RepositoryEntityFrameworkSqlServer.Mappers
{
    internal static class SupplierAttributeMapper
    {
        public static SupplierAttributeModel ToDomain(this SupplierAttributeEntity entity) => new SupplierAttributeModel
        {
            Id = entity.Id,
            SupplierId = entity.SupplierId,
            AttributeName = entity.AttributeName,
            AttributeValue = entity.AttributeValue
        };

        public static SupplierAttributeEntity ToEntity(this SupplierAttributeModel domain, int supplierId) => new SupplierAttributeEntity
        {
            Id = domain.Id,
            SupplierId = supplierId,
            AttributeName = domain.AttributeName,
            AttributeValue = domain.AttributeValue
        };
    }
}
