using Application.UseCases.SupplierAttribute;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierAttributeController : ControllerBase
    {
        private readonly IDeleteSupplierAttributeByIdUseCase _deleteSupplierAttributeByIdUseCase;

        public SupplierAttributeController(IDeleteSupplierAttributeByIdUseCase deleteSupplierAttributeByIdUseCase)
        {
            _deleteSupplierAttributeByIdUseCase = deleteSupplierAttributeByIdUseCase;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _deleteSupplierAttributeByIdUseCase.ExecuteAsync(id);

            return Ok();
        }
    }
}
