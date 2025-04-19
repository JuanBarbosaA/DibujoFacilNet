using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace backend.Utilities
{
    public static class EncryptUtility
    {
        // Método público para verificar si el hash es BCrypt
        public static bool IsBCryptHash(string hash)
        {
            return hash.StartsWith("$2a$") ||
                   hash.StartsWith("$2b$") ||
                   hash.StartsWith("$2x$") ||
                   hash.StartsWith("$2y$");
        }

        // Generar hash BCrypt (para nuevos usuarios)
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        // Verificar contraseña (compatible con SHA256 y BCrypt)
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (IsBCryptHash(storedHash))
            {
                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            else
            {
                // Para migración de usuarios con SHA256
                string sha256Hash = HashWithSHA256(password);
                return sha256Hash.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
            }
        }

        // Migrar de SHA256 a BCrypt
        public static string MigrateFromSHA256(string password)
        {
            return HashPassword(password);
        }

        // Método privado para SHA256 (solo para migración)
        private static string HashWithSHA256(string input)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}