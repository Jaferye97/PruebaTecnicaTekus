namespace Domain.Models.Service
{
    public class ServiceWithCountryModel : ServiceModel
    {
        public IList<ServiceCountryDetailModel> ServiceCountry { get; set; } = new List<ServiceCountryDetailModel>();
    }

    public class ServiceCountryDetailModel : ServiceCountryModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
