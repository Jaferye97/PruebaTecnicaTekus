using Application.Ports.Dependencies;

namespace Application.UseCases.Authentication.Implementations
{
    public class AuthenticationUserUseCase
    {
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;

        private const int _DEFAULT_USER_ID = 1;
        private const string _DEFAULT_USER_NAME = "admin";
        private const string _DEFAULT_ROLE = "Admin";

        private const string _DEFAULT_PASSWORD_HASH = "AA5jz+m2orq2jWQUOJjRdoiGwtdIo0yc5oQ4RX2JslMLOCS168jvjSEUIDGGCQSp5w==";

        public AuthenticationUserUseCase(
            IJwtService jwtService,
            IPasswordHasher passwordHasher)
        {
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public Task<string?> ExecuteAsync(string username, string password)
        {
            if (!username.Equals(_DEFAULT_USER_NAME, StringComparison.OrdinalIgnoreCase))
                return Task.FromResult<string?>(null);

            if (!_passwordHasher.Verify(password, _DEFAULT_PASSWORD_HASH))
                return Task.FromResult<string?>(null);

            var token = _jwtService.GenerateToken(
                _DEFAULT_USER_ID,
                _DEFAULT_USER_NAME,
                _DEFAULT_ROLE
            );

            return Task.FromResult<string?>(token);
        }
    }
}
