using System.Security.Cryptography;
using Application.Ports.Dependencies;

namespace TokenService
{
    public class Pbkdf2PasswordHasher : IPasswordHasher
    {
        private const int _ITERATIONS = 100_000;
        private const int _SALT_SIZE = 16;
        private const int _KEY_SIZE = 32;

        public string Hash(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[_SALT_SIZE];
            rng.GetBytes(salt);

            using var derive = new Rfc2898DeriveBytes(password, salt, _ITERATIONS, HashAlgorithmName.SHA256);
            var key = derive.GetBytes(_KEY_SIZE);

            var result = new byte[1 + _SALT_SIZE + _KEY_SIZE];
            result[0] = 0;
            Buffer.BlockCopy(salt, 0, result, 1, _SALT_SIZE);
            Buffer.BlockCopy(key, 0, result, 1 + _SALT_SIZE, _KEY_SIZE);

            return Convert.ToBase64String(result);
        }

        public bool Verify(string password, string storedHash)
        {
            var bytes = Convert.FromBase64String(storedHash);

            var salt = new byte[_SALT_SIZE];
            Buffer.BlockCopy(bytes, 1, salt, 0, _SALT_SIZE);

            var storedKey = new byte[_KEY_SIZE];
            Buffer.BlockCopy(bytes, 1 + _SALT_SIZE, storedKey, 0, _KEY_SIZE);

            using var derive = new Rfc2898DeriveBytes(password, salt, _ITERATIONS, HashAlgorithmName.SHA256);
            var testKey = derive.GetBytes(_KEY_SIZE);

            return CryptographicOperations.FixedTimeEquals(testKey, storedKey);
        }
    }
}
