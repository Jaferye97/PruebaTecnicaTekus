using System.ComponentModel.DataAnnotations.Schema;
using RepositoryEntityFrameworkSqlServer.Entities.Constants;

namespace RepositoryEntityFrameworkSqlServer.Entities
{
    [Table("Supplier")]
    public class SupplierEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string TaxId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<SupplierAttributeEntity> SupplierAttribute { get; set; } = new List<SupplierAttributeEntity>();
    }
}
