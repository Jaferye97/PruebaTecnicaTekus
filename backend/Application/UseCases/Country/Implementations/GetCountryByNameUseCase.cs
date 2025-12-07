using Application.Services;
using Domain.Models.Country;

namespace Application.UseCases.Country.Implementations
{
    public class GetCountryByNameUseCase : IGetCountryByNameUseCase
    {
        private readonly ICountriesService _countriesService;

        public GetCountryByNameUseCase(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        public async Task<List<CountryModel>> GetCountriesAsync(string name)
        {
            var countries = await _countriesService.GetCountriesAsync();

            return countries.Where(x => x.Name
                                .Contains(name, StringComparison.InvariantCultureIgnoreCase))
                            .ToList();
        }
    }
}
