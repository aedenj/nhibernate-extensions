using System;
using System.Security.Cryptography;

namespace NHibernateExtensions.SaltedAndEncryptedProperty {
    /// <summary>
    /// Provides various extension methods for the Encryptor interface.
    /// </summary>
    /// <remarks>
    /// Should I make Encryptor an abstract class and put this method
    /// in it? hmmmmmmm.......
    /// </remarks>
    public static class EncryptorExtenstions {
        /// <summary>
        /// Generates a base 64 string that is suitable as a salt.
        /// </summary>
        /// <param name="Encryptor">The encryptor</param>
        /// <returns>String - A base 64 string</returns>
        public static string GenerateSalt(this Encryptor Encryptor) {
            var Data = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(Data);

            return Convert.ToBase64String(Data);
        }
    }
}
