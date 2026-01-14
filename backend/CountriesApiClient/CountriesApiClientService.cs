using System.Net.Http.Json;
using Application.Ports.CountriesApiClient;
using Domain.Models.Country;

namespace CountriesApiClient;

public class CountriesApiClientService(
        HttpClient httpClient
    ) : ICountriesApiClientPort
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<CountryModel>> GetAllAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Model.CountryModel>>("https://restcountries.com/v3.1/all?fields=cca2,cca3,name");

        return response.Select(c => new CountryModel
        {
            Name = c.Name.Common,
            Code = c.Cca2
        }).ToList();
    }
}
