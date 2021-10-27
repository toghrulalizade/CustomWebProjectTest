using Core.Utilities.Resource.UsableModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Helper
{
    public static class RegisterHelper
    {
        public static CredentialPasswordModel GenerateSaltedHash(string password)
        {
            var saltBytes = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            CredentialPasswordModel hashSalt = new CredentialPasswordModel { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }
    }
}
