using Application.UseCases.Authentication.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationUserUseCase _authenticationUserUseCase;

        public AuthController(AuthenticationUserUseCase authenticationUserUseCase)
        {
            _authenticationUserUseCase = authenticationUserUseCase;
        }

        public record LoginRequest(string Username, string Password);

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authenticationUserUseCase.ExecuteAsync(request.Username, request.Password);

            if (token == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { token });
        }
    }
}
