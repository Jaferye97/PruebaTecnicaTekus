namespace RepositoryEntityFrameworkSqlServerV2.Mappers;

internal static class SupplierMapper
{
    public static SupplierModel ToDomain(this SupplierEntity entity) => new SupplierModel
    {
        Id = entity.Id,
        Name = entity.Name,
        Email = entity.Email,
        TaxId = entity.TaxId,
        SupplierAttribute = entity.SupplierAttribute?
            .Select(a => a.ToDomain())
            .ToList() ?? new List<SupplierAttributeModel>()
    };

    public static SupplierEntity ToEntity(this SupplierModel domain) => new SupplierEntity
    {
        Id = domain.Id,
        Name = domain.Name,
        Email = domain.Email,
        TaxId = domain.TaxId,
        SupplierAttribute = domain.SupplierAttribute?
            .Select(a => a.ToEntity(domain.Id))
            .ToList() ?? new List<SupplierAttributeEntity>()
    };
}
