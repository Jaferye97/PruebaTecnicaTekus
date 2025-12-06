using Application.Ports.Dependencies;

namespace Application.UseCases.Authentication.Implementations
{
    public class AuthenticationUserUseCase
    {
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;

        private const int _defaultUserId = 1;
        private const string _defaultUsername = "admin";
        private const string _defaultRole = "Admin";

        private const string _defaultPasswordHash = "AA5jz+m2orq2jWQUOJjRdoiGwtdIo0yc5oQ4RX2JslMLOCS168jvjSEUIDGGCQSp5w==";

        public AuthenticationUserUseCase(
            IJwtService jwtService,
            IPasswordHasher passwordHasher)
        {
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public Task<string?> ExecuteAsync(string username, string password)
        {
            if (!username.Equals(_defaultUsername, StringComparison.OrdinalIgnoreCase))
                return Task.FromResult<string?>(null);

            if (!_passwordHasher.Verify(password, _defaultPasswordHash))
                return Task.FromResult<string?>(null);

            var token = _jwtService.GenerateToken(
                _defaultUserId,
                _defaultUsername,
                _defaultRole
            );

            return Task.FromResult<string?>(token);
        }
    }
}
