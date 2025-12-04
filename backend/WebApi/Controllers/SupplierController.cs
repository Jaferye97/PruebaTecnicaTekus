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
        private readonly IGetSupplierByIdUseCase _getSupplierByIdUseCase;

        public SupplierController(
            IAddSupplierUseCase addSupplierUseCase,
            IGetSupplierByIdUseCase getSupplierByIdUseCase
        )
        {
            _addSupplierUseCase = addSupplierUseCase;
            _getSupplierByIdUseCase = getSupplierByIdUseCase;
        }

        [HttpPost()]
        public async Task<IActionResult> AddAsync([FromBody] SupplierModel model)
        {
            var result = await _addSupplierUseCase.ExecuteAsync(model);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var result = await _getSupplierByIdUseCase.ExecuteAsync(id);

            return result == null ? NotFound() : Ok(result);
        }
    }
}
