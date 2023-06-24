using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WEBAPIFLUENT.Repository
{
    public class AesEncryption
    {
        private static byte[] GenerateRandomKey(int keySize)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = keySize;
                aes.GenerateKey();
                return aes.Key;
            }
        }

        public static string Encrypt(string plainText, string secretKey, int keySize)
        {
            byte[] key = Encoding.UTF8.GetBytes(secretKey);

            using (var aes = Aes.Create())
            {
                aes.KeySize = keySize;
                aes.Key = GenerateRandomKey(keySize);
                aes.Mode = CipherMode.CBC;

                byte[] iv = aes.IV;

                using (var encryptor = aes.CreateEncryptor())
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    byte[] encryptedBytes = memoryStream.ToArray();
                    byte[] result = new byte[iv.Length + encryptedBytes.Length];
                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(encryptedBytes, 0, result, iv.Length, encryptedBytes.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }

        public static string Decrypt(string encryptedText, string secretKey, int keySize)
        {
            byte[] key = Encoding.UTF8.GetBytes(secretKey);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] iv = new byte[16];
            byte[] cipherBytes = new byte[encryptedBytes.Length - iv.Length];

            Buffer.BlockCopy(encryptedBytes, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(encryptedBytes, iv.Length, cipherBytes, 0, cipherBytes.Length);

            using (var aes = Aes.Create())
            {
                aes.KeySize = keySize;
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;

                using (var decryptor = aes.CreateDecryptor())
                using (var memoryStream = new MemoryStream(cipherBytes))
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (var streamReader = new StreamReader(cryptoStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }




}
