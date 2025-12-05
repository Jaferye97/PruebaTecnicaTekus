using Application.UseCases.Service;
using Domain.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IAddServiceWithCountryUseCase _addServiceWithCountryUseCase;

        public ServiceController(IAddServiceWithCountryUseCase addServiceWithCountryUseCase)
        {
            _addServiceWithCountryUseCase = addServiceWithCountryUseCase;
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] ServiceWithCountryModel model)
        {
            var result = await _addServiceWithCountryUseCase.ExecuteAsync(model);
            return result ? Ok() : BadRequest();
        }
    }
}
