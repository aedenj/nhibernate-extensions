namespace NHibernateExtensions.SaltedAndEncryptedProperty
{
    /// <summary>
    /// Provides decryption services
    /// </summary>
    public interface Decryptor
    {
        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="StringToDecrypt">The string  to encrypt</param>
        /// <param name="Salt">Used to encrypt the string if the underlying implementation needs it</param>
        /// <returns>An encrypted string</returns>
        /// <exception cref="SaltRequiredException">Thrown if the underlying implementation needs a salt to encrypt</exception>
        string Decrypt(string StringToDecrypt, string Salt);
    }
}
