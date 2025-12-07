namespace Domain.Models.User
{
    public class UserModel
    {
        public int Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public string PasswordHash { get; init; } = string.Empty;
        public string Role { get; init; } = "User";
    }
}
