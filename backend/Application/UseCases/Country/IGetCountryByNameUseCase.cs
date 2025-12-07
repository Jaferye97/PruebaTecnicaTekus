using Domain.Models.Country;

namespace Application.UseCases.Country
{
    public interface IGetCountryByNameUseCase
    {
        Task<List<CountryModel>> GetCountriesAsync(string name);
    }
}
