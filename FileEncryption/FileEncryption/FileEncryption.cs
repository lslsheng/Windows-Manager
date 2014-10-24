using System;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;

namespace FileEncryption
{
    /// <summary>
    /// Takes an MD5 key and encrypts/decrypts files.
    /// </summary>
    class FileEncryption
    {
        /// <summary>
        /// The MD5 key.
        /// </summary>
        private byte[] key;

        /// <summary>
        /// Encrypts or decrypts file using AES with the given key.
        /// </summary>
        /// <param name="key">The key to use. Probably an MD5 hash derived from a gesture.</param>
        public FileEncryption(string key)
        {
            this.key = ConvertHashToBytes(key);
        }

        /// <summary>
        /// Encrypts the given file with the key.
        /// </summary>
        /// <param name="fileName">The path to the file.</param>
        /// <returns></returns>
        public byte[] EncryptFile(string fileName)
        {
            return DataEncryption.AES_Encrypt(File.ReadAllBytes(fileName), key);
        }

        /// <summary>
        /// Decrypts the given file with the key. Overwrites the file.
        /// </summary>
        /// <param name="fileName">The path to the file.</param>
        public byte[] DecryptFile(string fileName)
        {
            return DataEncryption.AES_Decrypt(File.ReadAllBytes(fileName), key);
        }

        /// <summary>
        /// Convert an MD5 hash string to its byte array.
        /// 
        /// From http://stackoverflow.com/a/8235530, licensed under CC-SA.
        /// </summary>
        /// <param name="hexString">The MD5 hash.</param>
        /// <returns></returns>
        private byte[] ConvertHashToBytes(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] HexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < HexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return HexAsBytes;
        }

        /// <summary>
        /// From http://www.codeproject.com/Articles/769741/Csharp-AES-bits-Encryption-Library-with-Salt,
        /// licensed in the public domain.
        /// </summary>
        private class DataEncryption
        {
            public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
            {
                byte[] encryptedBytes = null;

                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.
                byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {
                        AES.KeySize = 256;
                        AES.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                            cs.Close();
                        }
                        encryptedBytes = ms.ToArray();
                    }
                }

                return encryptedBytes;
            }

            public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
            {
                byte[] decryptedBytes = null;

                // Set your salt here, change it to meet your flavor:
                // The salt bytes must be at least 8 bytes.
                byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                using (MemoryStream ms = new MemoryStream())
                {
                    using (RijndaelManaged AES = new RijndaelManaged())
                    {
                        AES.KeySize = 256;
                        AES.BlockSize = 128;

                        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                        AES.Key = key.GetBytes(AES.KeySize / 8);
                        AES.IV = key.GetBytes(AES.BlockSize / 8);

                        AES.Mode = CipherMode.CBC;

                        using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                            cs.Close();
                        }
                        decryptedBytes = ms.ToArray();
                    }
                }

                return decryptedBytes;
            }
        }

    }
}
