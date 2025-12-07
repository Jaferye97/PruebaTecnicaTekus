namespace Application.Ports.Dependencies
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string username, string role);
    }
}
