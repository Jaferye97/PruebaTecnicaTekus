using System.ComponentModel.DataAnnotations.Schema;
using RepositoryEntityFrameworkSqlServer.Entities.Constants;

namespace RepositoryEntityFrameworkSqlServer.Entities
{
    [Table("Service")]
    public class ServiceEntity : IEntity<int>
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }

        public SupplierEntity? Supplier { get; set; }

        public ICollection<ServiceCountryEntity> ServiceCountry { get; set; } = new List<ServiceCountryEntity>();
    }
}
