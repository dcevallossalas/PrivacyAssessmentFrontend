using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLibrary.AssessmentLogic
{
    /// <summary>
    /// FrmApiKey
    /// Ciphers and deciphers keys
    /// </summary>
    public class ApiKey
    {
        // Ciphers information
        public static string Encrypt(string plainText, string keyText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (SHA256 sha = SHA256.Create())
                {
                    aes.Key = sha.ComputeHash(Encoding.UTF8.GetBytes(keyText));
                }

                aes.GenerateIV();
                byte[] iv = aes.IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, iv))
                using (var ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);

                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // Deciphers information
        public static string Decrypt(string cipherTextBase64, string keyText)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherTextBase64);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (SHA256 sha = SHA256.Create())
                {
                    aes.Key = sha.ComputeHash(Encoding.UTF8.GetBytes(keyText));
                }

                byte[] iv = new byte[16];
                byte[] cipher = new byte[fullCipher.Length - 16];

                Array.Copy(fullCipher, 0, iv, 0, iv.Length);
                Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(cipher))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}