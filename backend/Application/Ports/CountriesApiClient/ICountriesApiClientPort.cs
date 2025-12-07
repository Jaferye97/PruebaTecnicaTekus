using Domain.Models.Country;

namespace Application.Ports.CountriesApiClient
{
    public interface ICountriesApiClientPort
    {
        Task<List<CountryModel>> GetAllAsync();
    }
}
