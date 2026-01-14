namespace RepositoryEntityFrameworkSqlServerV2.Entities;

[Table("ServiceCountry")]
public class ServiceCountryEntity : IEntity<int>
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public int CountryId { get; set; }

    public ServiceEntity? Service { get; set; }
    public CountryEntity? Country { get; set; }
}
