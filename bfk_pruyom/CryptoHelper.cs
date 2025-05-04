using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bfk_pruyom
{
    class CryptoHelper
    {
        private static readonly string key = "ppvFwXaDqOAP9bswf7dH50620vUv2JSh"; 
        private static readonly string iv = "sHCaSCIHmBpZzcJw";

        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                var msEncrypt = new MemoryStream();
                var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                    swEncrypt.Write(plainText);

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
                var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                var srDecrypt = new StreamReader(csDecrypt);

                return srDecrypt.ReadToEnd();
            }
        }
    }
}
