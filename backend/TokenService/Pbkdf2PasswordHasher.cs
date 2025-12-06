using System.Security.Cryptography;
using Application.Ports.Dependencies;

namespace TokenService
{
    public class Pbkdf2PasswordHasher : IPasswordHasher
    {
        private const int Iterations = 100_000;
        private const int SaltSize = 16;
        private const int KeySize = 32;

        public string Hash(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[SaltSize];
            rng.GetBytes(salt);

            using var derive = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            var key = derive.GetBytes(KeySize);

            var result = new byte[1 + SaltSize + KeySize];
            result[0] = 0;
            Buffer.BlockCopy(salt, 0, result, 1, SaltSize);
            Buffer.BlockCopy(key, 0, result, 1 + SaltSize, KeySize);

            return Convert.ToBase64String(result);
        }

        public bool Verify(string password, string storedHash)
        {
            var bytes = Convert.FromBase64String(storedHash);

            var salt = new byte[SaltSize];
            Buffer.BlockCopy(bytes, 1, salt, 0, SaltSize);

            var storedKey = new byte[KeySize];
            Buffer.BlockCopy(bytes, 1 + SaltSize, storedKey, 0, KeySize);

            using var derive = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            var testKey = derive.GetBytes(KeySize);

            return CryptographicOperations.FixedTimeEquals(testKey, storedKey);
        }
    }
}
