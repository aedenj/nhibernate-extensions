using System;



namespace NHibernateExtensions.SaltedAndEncryptedProperty
{
    /// <summary>
    /// Stores the key and initial vector in memory
    /// </summary>
    public class InMemoryContainer
        : KeyAndInitialVectorContainer
    {
        #region Constructors
        protected InMemoryContainer(byte[] Key, byte[] InitialVector)
        {
            this.Key = Key;
            this.InitialVector = InitialVector;
        }

        protected InMemoryContainer(string Key, string InitialVector)
        {
            this.Key = Convert.FromBase64String(Key);
            this.InitialVector = Convert.FromBase64String(InitialVector);
        }
        #endregion



        #region Factory Methods
        /// <summary>
        /// Provides an instance of InMemoryContainer.
        /// </summary>
        /// <param name="TheKey">The key to store</param>
        /// <param name="TheIV">The initial vector to store</param>
        /// <returns>InMemoryContainer - An instance of the class</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the key or iv are empty or null
        /// </exception>
        public static InMemoryContainer Create(byte[] TheKey, byte[] TheIV)
        {
            if (TheKey == null)
                throw new ArgumentNullException("TheKey");

            if (TheIV == null)
                throw new ArgumentNullException("TheIV");

            //TODO: My gut says this class should be a singleton at some point
            return new InMemoryContainer(TheKey, TheIV);
        }



        /// <summary>
        /// Provides an instance of InMemoryContainer.
        /// </summary>
        /// <param name="TheKey">The key to store</param>
        /// <param name="TheIV">The initial vector to store</param>
        /// <returns>InMemoryContainer - An instance of the class</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the key or iv are empty or null
        /// </exception>
        public static InMemoryContainer Create(string TheKey, string TheIV)
        {
            if (string.IsNullOrEmpty(TheKey))
                throw new ArgumentNullException("TheKey");

            if (string.IsNullOrEmpty(TheIV))
                throw new ArgumentNullException("TheIV");

            //TODO: My gut says this class should be a singleton at some point
            return new InMemoryContainer(TheKey, TheIV);
        }
        #endregion



        #region KeyAndInitialVectorContainer Members
        public byte[] Key { get; private set; }
        public byte[] InitialVector { get; private set; }



        public bool HasKey
        {
            get { return Key != null; }
        }



        public bool HasInitialVector
        {
            get { return InitialVector != null; }
        }
        #endregion
    }
}
