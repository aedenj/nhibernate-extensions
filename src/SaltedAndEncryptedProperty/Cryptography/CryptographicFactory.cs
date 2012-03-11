namespace NHibernateExtensions.SaltedAndEncryptedProperty
{
    sealed class CryptographyFactory
    {

        public Encryptor CreateEncryptor()
        {
            return new RijndaelEncryptor(Container.Key, Container.InitialVector); 
        }


        public Decryptor CreateDecryptor()
        {         
            return new RijndaelDecryptor(Container.Key, Container.InitialVector);
        }



        #region Private Fields
        private static readonly KeyAndInitialVectorContainer Container = InMemoryContainer.Create("h0BTNkxUnSbL8cdwd0zyAA6w8UpRS5yCjEBgJUzmAf0=", "g3uIe0rfylegngX1fZUKvw==");
        #endregion
    }
}
