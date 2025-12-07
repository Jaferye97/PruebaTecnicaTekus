using Application.Ports.CountriesApiClient;
using Domain.Models.Country;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services.Implementations
{
    public class CachedCountriesService : ICountriesService
    {
        private const string _CACHE_KEY = "countries_cache";
        private readonly IMemoryCache _cache;
        private readonly ICountriesApiClientPort _apiClient;

        public CachedCountriesService(IMemoryCache cache, ICountriesApiClientPort apiClient)
        {
            _cache = cache;
            _apiClient = apiClient;
        }

        public async Task<List<CountryModel>> GetCountriesAsync()
        {
            if (_cache.TryGetValue(_CACHE_KEY, out List<CountryModel> countries))
                return countries;

            countries = await _apiClient.GetAllAsync();

            _cache.Set(_CACHE_KEY, countries, TimeSpan.FromHours(24));

            return countries;
        }
    }
}
