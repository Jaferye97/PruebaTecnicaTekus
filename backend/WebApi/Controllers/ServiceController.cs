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
        private readonly IGetServiceByIdUseCase _getServiceByIdUseCase;
        private readonly IUpdateServiceUseCase _updateServiceUseCase;

        public ServiceController(
            IAddServiceWithCountryUseCase addServiceWithCountryUseCase,
            IGetServiceByIdUseCase getServiceByIdUseCase,
            IUpdateServiceUseCase updaterServiceUseCase)
        {
            _addServiceWithCountryUseCase = addServiceWithCountryUseCase;
            _getServiceByIdUseCase = getServiceByIdUseCase;
            _updateServiceUseCase = updaterServiceUseCase;
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] ServiceWithCountryModel model)
        {
            var result = await _addServiceWithCountryUseCase.ExecuteAsync(model);
            return result ? Ok() : BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _getServiceByIdUseCase.ExecuteAsync(id);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] ServiceModel model)
        {
            var result = await _updateServiceUseCase.ExecuteAsync(model);

            return result == false ? NotFound() : Ok();
        }
    }
}
