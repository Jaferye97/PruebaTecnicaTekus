using Application.UseCases.Country;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IGetCountryByNameUseCase _getCountryByNameUseCase;

        public CountryController(IGetCountryByNameUseCase getCountryByNameUseCase)
        {
            _getCountryByNameUseCase = getCountryByNameUseCase;
        }

        [HttpGet("CountriesByName/{name}")]
        public async Task<IActionResult> GetGetAsync([FromRoute] string name)
        {
            var list = await _getCountryByNameUseCase.GetCountriesAsync(name);
            return Ok(list);
        }
    }
}
