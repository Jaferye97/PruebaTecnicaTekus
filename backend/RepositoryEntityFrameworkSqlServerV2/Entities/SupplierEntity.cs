namespace RepositoryEntityFrameworkSqlServerV2.Entities;

[Table("Supplier")]
public class SupplierEntity : IEntity<int>
{
    public int Id { get; set; }
    public string TaxId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<SupplierAttributeEntity> SupplierAttribute { get; set; } = new List<SupplierAttributeEntity>();
    public ICollection<ServiceEntity> Service { get; set; } = new List<ServiceEntity>();
}
