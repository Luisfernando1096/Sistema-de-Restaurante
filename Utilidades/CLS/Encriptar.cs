namespace Utilidades.CLS
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public static class ConnectionStringEncryptor
    {
        private static readonly byte[] key = { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
        private static readonly byte[] iv = { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF };

        public static string EncryptConnectionString(string connectionString)
        {
            byte[] encryptedBytes;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(connectionString);
                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        encryptedBytes = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptConnectionString(string encryptedConnectionString)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedConnectionString);
            string decryptedString = null;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            decryptedString = reader.ReadToEnd();
                        }
                    }
                }
            }

            return decryptedString;
        }
    }

}
