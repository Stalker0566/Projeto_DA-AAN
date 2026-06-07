using System;
using System.Security.Cryptography;
using System.Text;

namespace Projeto_DA
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16; // 128 bit
        private const int KeySize = 32;  // 256 bit
        private const int Iterations = 100000;
        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

        /// <summary>
        /// Gera um hash seguro PBKDF2 da palavra-passe.
        /// Devolve uma string no formato: "base64_salt:base64_hash"
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("A palavra-passe não pode ser vazia.");

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithm,
                KeySize);

            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        /// <summary>
        /// Verifica se a palavra-passe corresponde ao hash guardado.
        /// Suporta fallback para texto limpo no caso de utilizadores antigos.
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
                return false;

            // Fallback: se não contém o separador ":", assumimos que é uma senha antiga em texto limpo
            if (!hashedPassword.Contains(':'))
            {
                return password == hashedPassword;
            }

            try
            {
                var parts = hashedPassword.Split(':');
                if (parts.Length != 2)
                    return password == hashedPassword; // Fallback se o formato for inválido

                byte[] salt = Convert.FromBase64String(parts[0]);
                byte[] hash = Convert.FromBase64String(parts[1]);

                byte[] testHash = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    Iterations,
                    HashAlgorithm,
                    KeySize);

                return CryptographicOperations.FixedTimeEquals(hash, testHash);
            }
            catch
            {
                // Fallback em caso de qualquer erro na decodificação Base64
                return password == hashedPassword;
            }
        }
    }
}
