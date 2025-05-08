using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApp.Services
{
    public class HashService : IHashService
    {
        private readonly string _secretKey = "your_secret_key_123"; // Asegúrate de que la clave sea segura

        public string GenerateHash(string data)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(hash); // Retorna el hash en formato Base64
            }
        }

        public bool ValidateHash(string hash, string data)
        {
            // Generar el hash del dato proporcionado y compararlo con el hash dado
            var computedHash = GenerateHash(data);
            return computedHash == hash;
        }
    }
}
