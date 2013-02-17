using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace NHibernateExtensions.SaltedAndEncryptedProperty {
    /// <summary>
    /// Provides the ability to decrypt a string that has been encrypted using 
    /// the Rijndael algorithm
    /// </summary>
    sealed class RijndaelDecryptor
        : RijndaelManagedBase, Decryptor {
        
        public RijndaelDecryptor(byte[] TheKey, byte[] TheInitialVector)
            : base(TheKey, TheInitialVector) {}            
        
        /// <summary>
        /// Decrypts a string that was encrypted using the Rijndael algorithm.
        /// </summary>
        /// <param name="StringToDecrypt">The target string</param>
        /// <param name="Salt">The salt to use</param>
        /// <returns>string - the decrypted string</returns>
        /// <exception cref="SaltRequiredException">
        /// Thrown if the salt is null or empty
        /// </exception>
        public string Decrypt(string StringToDecrypt, string Salt) {
            if (string.IsNullOrEmpty(Salt))
                throw new SaltRequiredException("RijndaelDecryptor.Decrypt - Salt cannot by null or empty");

            var BytesToDecrypt = Convert.FromBase64String(StringToDecrypt);
            var Decryptor = RijndaelAlg.CreateDecryptor(Key, InitialVector);

            string DecryptedMessage;
            using(var MemoryStream = new MemoryStream(BytesToDecrypt))
            {
                using (var CryptoStream = new CryptoStream(MemoryStream, Decryptor, CryptoStreamMode.Read))
                {
                    var UnencryptedBytes = new byte[BytesToDecrypt.Length];
                    var DecryptedByteCount = CryptoStream.Read(UnencryptedBytes, 0, UnencryptedBytes.Length);

                    DecryptedMessage = Encoding.UTF8.GetString(UnencryptedBytes, 0, DecryptedByteCount);
                }                
            }

            return DecryptedMessage.Remove(DecryptedMessage.IndexOf(Salt));
        }
    }
}
