namespace Services
{
    using Contracts;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class HashService : IHashService
    {
        public string Hash(string str)
        {
            str = str + "Salt@#$%";
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
