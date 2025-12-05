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

        public ServiceController(
            IAddServiceWithCountryUseCase addServiceWithCountryUseCase,
            IGetServiceByIdUseCase getServiceByIdUseCase
        )
        {
            _addServiceWithCountryUseCase = addServiceWithCountryUseCase;
            _getServiceByIdUseCase = getServiceByIdUseCase;
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
    }
}
