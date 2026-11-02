using System;
using System.Security.Cryptography;

namespace WebApplicationDocLab.Security
{
    // PBKDF2-based password hashing. Stored format: "v2.<iterations>.<saltBase64>.<hashBase64>".
    // Verify() also accepts a legacy plaintext value for backward compatibility with
    // accounts created before hashing was introduced; callers should re-hash and save
    // the password after a successful legacy verification (see NeedsRehash).
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100_000;
        private const string Prefix = "v2";

        public static string Hash(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);

                var hash = ComputeHash(password, salt, Iterations);
                return $"{Prefix}.{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
            }
        }

        public static bool Verify(string password, string stored, out bool needsRehash)
        {
            needsRehash = false;

            if (string.IsNullOrEmpty(stored) || password == null)
            {
                return false;
            }

            var parts = stored.Split('.');
            if (parts.Length != 4 || parts[0] != Prefix)
            {
                // Legacy plaintext account created before hashing was introduced.
                bool matches = stored == password;
                needsRehash = matches;
                return matches;
            }

            int iterations = int.Parse(parts[1]);
            var salt = Convert.FromBase64String(parts[2]);
            var expectedHash = Convert.FromBase64String(parts[3]);

            var actualHash = ComputeHash(password, salt, iterations);
            return SlowEquals(actualHash, expectedHash);
        }

        private static byte[] ComputeHash(string password, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }
    }
}
