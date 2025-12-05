using Application.UseCases.ServiceCountry;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCountryController : ControllerBase
    {
        private readonly IDeleteServiceCountryByIdUseCase _deleteServiceCountryByIdUseCase;

        public ServiceCountryController(IDeleteServiceCountryByIdUseCase deleteServiceCountryByIdUseCase)
        {
            _deleteServiceCountryByIdUseCase = deleteServiceCountryByIdUseCase;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _deleteServiceCountryByIdUseCase.ExecuteAsync(id);

            return Ok();
        }
    }
}
