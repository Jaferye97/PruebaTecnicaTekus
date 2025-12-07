using Domain.Models.Country;

namespace Application.Services
{
    public interface ICountriesService
    {
        Task<List<CountryModel>> GetCountriesAsync();
    }
}
