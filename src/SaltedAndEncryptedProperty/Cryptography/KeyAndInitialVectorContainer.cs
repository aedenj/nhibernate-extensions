namespace NHibernateExtensions.SaltedAndEncryptedProperty {
    /// <summary>
    /// An abstraction representing a container for a key and initial vector
    /// for symmetric cryptography.
    /// </summary>
    public interface KeyAndInitialVectorContainer {
        byte[] Key { get; }
        byte[] InitialVector { get; }
        bool HasKey { get;  }
        bool HasInitialVector { get; }
    }
}
