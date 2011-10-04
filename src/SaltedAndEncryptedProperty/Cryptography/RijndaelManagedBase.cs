using System.Security.Cryptography;



namespace NHibernateExtensions.SaltedAndEncryptedProperty
{
    /// <summary>
    /// Provides basic setup for the use RijndaelManaged encryption/decryption algorithm
    /// </summary>
    /// <remarks>
    /// The CipherMode chosen for the algorithm is Cipher Block Chaining (CBC)s
    /// </remarks>
    internal abstract class RijndaelManagedBase
    {
        protected RijndaelManagedBase(byte[] TheKey, byte[] TheInitialVector)
        {
            RijndaelAlg = new RijndaelManaged {Mode = CipherMode.CBC};
            Key = TheKey;
            InitialVector = TheInitialVector;
        }


        #region Protected Properties
        protected RijndaelManaged RijndaelAlg { get; set; }
        protected byte[] Key { get; set; }
        protected byte[] InitialVector { get; set; }
        #endregion

    }
}
