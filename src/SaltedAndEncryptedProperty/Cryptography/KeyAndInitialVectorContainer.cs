namespace NHibernateExtensions.SaltedAndEncryptedProperty
{
    /// <summary>
    /// An abstraction representing a container for a key and initial vector
    /// for symmetric cryptography.
    /// </summary>
    public interface KeyAndInitialVectorContainer
    {
        /// <summary>
        /// The encryption key
        /// </summary>
        byte[] Key
        {
            get; 
        }



        /// <summary>
        /// The self-described initial vector
        /// </summary>
        byte[] InitialVector
        {
            get;
        }



        /// <summary>
        /// Does the container have the encryption key?
        /// </summary>
        bool HasKey
        {
            get; 
        }



        /// <summary>
        /// Does the container have the initial vector?
        /// </summary>
        bool HasInitialVector
        { 
            get;
        }
    }
}
