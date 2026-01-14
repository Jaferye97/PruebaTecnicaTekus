namespace RepositoryEntityFrameworkSqlServerV2.Entities;

[Table("SupplierAttribute")]
public class SupplierAttributeEntity : IEntity<int>
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public string AttributeName { get; set; } = string.Empty;
    public string AttributeValue { get; set; } = string.Empty;
    public SupplierEntity? Supplier { get; set; }
}
