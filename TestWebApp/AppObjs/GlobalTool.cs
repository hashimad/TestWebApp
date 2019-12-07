using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TestWebApp.AppObjs
{
    public class GlobalTool
    {
        public static string CreateSalt(int size=128)
        {
           
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }


        //public string GenerateHash(string input, string salt)
        //{
        //    byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
        //    SHA256Managed sHA256ManagedString = new SHA256Managed();
        //    byte[] hash = sHA256ManagedString.ComputeHash(bytes);
        //    return Convert.ToBase64String(hash);
        //}
        public static string GetHash(string password, string salt)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

            return Convert.ToBase64String(hashedBytes);
        }

        public static bool ComparePasswordHash(string attemptedPassword, string originalPassword, string salt)
        {
            //string base64Hash = Convert.ToBase64String(originalPassword);
            string base64AttemptedHash = GetHash(attemptedPassword, salt);

            return originalPassword == base64AttemptedHash;
        }
      
    }
}