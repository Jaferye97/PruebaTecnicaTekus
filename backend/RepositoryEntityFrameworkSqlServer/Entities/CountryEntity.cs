using System.ComponentModel.DataAnnotations.Schema;
using RepositoryEntityFrameworkSqlServer.Entities.Constants;

namespace RepositoryEntityFrameworkSqlServer.Entities
{
    [Table("Country")]
    public class CountryEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public ICollection<ServiceCountryEntity> ServiceCountry { get; set; } = new List<ServiceCountryEntity>();
    }
}
