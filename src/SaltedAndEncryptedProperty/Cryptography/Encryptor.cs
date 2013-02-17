namespace NHibernateExtensions.SaltedAndEncryptedProperty {
    public interface Encryptor {
        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="StringToEncrypt">The string  to encrypt</param>
        /// <param name="Salt">The salt used to encrypt the string</param>
        /// <returns>An encrypted string</returns>
        /// <exception cref="SaltRequiredException">Thrown if the underlying implementation needs a salt to encrypt</exception>
        string Encrypt(string StringToEncrypt, string Salt);
    }
}
