using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;

namespace lab02_210042111
{
    public class DESEncryption : IEncryption
    {
        private string key;

        public DESEncryption(string key)
        {
            this.key = key;
        }

        public string Encrypt(string plainText)
        {
            byte[] encryptedBytes;

            using (DES des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = new byte[8]; // Initialization Vector (IV) set to zeros for simplicity

                ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    encryptedBytes = ms.ToArray(); // Capture the result here before the stream is disposed
                }
            }

            return Convert.ToBase64String(encryptedBytes); // Convert captured result to base64
        }

        public string Decrypt(string cipherText)
        {
            byte[] decryptedBytes;

            using (DES des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = new byte[8]; // Initialization Vector (IV) set to zeros for simplicity

                ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd(); // Read decrypted content
                    }
                }
            }
        }
    }
}
