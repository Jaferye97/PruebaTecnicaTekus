using Application.UseCases.Supplier;
using Domain.Models.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IAddSupplierUseCase _addSupplierUseCase;

        public SupplierController(
            IAddSupplierUseCase addSupplierUseCase
        )
        {
            _addSupplierUseCase = addSupplierUseCase;
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] SupplierModel model)
        {
            var result = await _addSupplierUseCase.ExecuteAsync(model);
            return Ok(result);
        }
    }
}
