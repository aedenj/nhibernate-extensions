using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace NHibernateExtensions.SaltedAndEncryptedProperty {
  /// <summary>
  /// Provides the ability to encrypt a string using the Rijndael algorithm
  /// </summary>
  internal sealed class RijndaelEncryptor
    : RijndaelManagedBase, Encryptor {
    public RijndaelEncryptor(byte[] TheKey, byte[] TheInitialVector)
      : base(TheKey, TheInitialVector) {}

    /// <summary>
    /// Encrypts a string using the Rijndael algorithm.
    /// </summary>
    /// <param name="StringToEncrypt">The target string</param>
    /// <param name="Salt">The salt to use</param>
    /// <returns>string - the decrypted string</returns>
    /// <exception cref="SaltRequiredException">
    /// Thrown if the salt is null or empty.
    /// </exception>
    public string Encrypt(string StringToEncrypt, string Salt) {
      if (string.IsNullOrEmpty(Salt))
        throw new SaltRequiredException("RijndaelEncryptor.Encrypt - Salt cannot by null or empty");

      var BytesToEncrypt = Encoding.UTF8.GetBytes(StringToEncrypt + Salt);
      var Encryptor = RijndaelAlg.CreateEncryptor(Key, InitialVector);

      byte[] Cipher;
      using (var MemoryStream = new MemoryStream()) {
        using (var CryptoStream = new CryptoStream(MemoryStream, Encryptor, CryptoStreamMode.Write)) {
          CryptoStream.Write(BytesToEncrypt, 0, BytesToEncrypt.Length);
          CryptoStream.FlushFinalBlock();
          Cipher = MemoryStream.ToArray();
        }
      }

      return Convert.ToBase64String(Cipher);
    }
    }
}