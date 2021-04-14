using System;
using System.Security.Cryptography;
using System.Text;

namespace Secrets.Models
{
    /// <summary>
    /// modified from the following post
    /// https://dotnetcodr.com/2015/10/23/encrypt-and-decrypt-plain-string-with-triple-des-in-c/
    /// </summary>
    public static class CryptoEngine
    {
        public class Secrets
        {
            public string Key { get; set; }
        }

        public static string Encrypt(string source, string key)
        {
            var byteHash = MD5.HashData(Encoding.UTF8.GetBytes(key));
            var tripleDes = new TripleDESCryptoServiceProvider
            {
                Key = byteHash, 
                Mode = CipherMode.ECB
            };
            
            var byteBuff = Encoding.UTF8.GetBytes(source);
            return Convert.ToBase64String(tripleDes.CreateEncryptor()
                .TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }

        public static string Decrypt(string encodedText, string key)
        {
            var byteHash = MD5.HashData(Encoding.UTF8.GetBytes(key));
            var tripleDes = new TripleDESCryptoServiceProvider
            {
                Key = byteHash, 
                Mode = CipherMode.ECB
            };
            var byteBuff = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(
                tripleDes
                    .CreateDecryptor()
                    .TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }
    }
}