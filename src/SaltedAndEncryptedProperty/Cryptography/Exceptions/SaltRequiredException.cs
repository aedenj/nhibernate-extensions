using System;

namespace NHibernateExtensions.SaltedAndEncryptedProperty
{
    /// <summary>
    /// Thrown in encryptor and decryptor implementations that require a salt 
    /// to encrypt or decrypt the target message.
    /// </summary>
    [Serializable]
    public sealed class SaltRequiredException
        : Exception
    {
        public SaltRequiredException() 
        {}

        

        public SaltRequiredException(string Message) : base(Message)
        {}



        public SaltRequiredException(string Message, Exception Inner) : base(Message, Inner)
        {}
    }
}
