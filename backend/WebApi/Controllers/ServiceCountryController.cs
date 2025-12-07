using Application.UseCases.ServiceCountry;
using Domain.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCountryController : ControllerBase
    {
        private readonly IDeleteServiceCountryByIdUseCase _deleteServiceCountryByIdUseCase;
        private readonly IAddServiceCountryUseCase _addServiceCountryUseCase;

        public ServiceCountryController(
            IDeleteServiceCountryByIdUseCase deleteServiceCountryByIdUseCase,
            IAddServiceCountryUseCase addServiceCountryUseCase
        )
        {
            _deleteServiceCountryByIdUseCase = deleteServiceCountryByIdUseCase;
            _addServiceCountryUseCase = addServiceCountryUseCase;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _deleteServiceCountryByIdUseCase.ExecuteAsync(id);

            return Ok();
        }

        [HttpPost("{serviceId}")]
        public async Task<IActionResult> AddAsync([FromRoute] int serviceId, [FromBody] List<ServiceCountryDetailModel> models)
        {
            var result = await _addServiceCountryUseCase.ExecuteAsync(serviceId, models);
            return result ? Ok() : BadRequest();
        }
    }
}
