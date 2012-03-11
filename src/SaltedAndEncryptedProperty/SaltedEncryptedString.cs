using System;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace NHibernateExtensions.SaltedAndEncryptedProperty 
{
    sealed class SaltedEncryptedString
        : IUserType
    {
        #region Constructors
        public SaltedEncryptedString()
        { }

        #endregion



        #region Public Properties
        public SqlType[] SqlTypes
        {
            get { return new[] { new SqlType(DbType.String), new SqlType(DbType.String) }; }
        }

        public Type ReturnedType
        {
            get { return typeof(string); }
        }

        public bool IsMutable
        {
            get { return false; }
        }
        #endregion


        #region Public Methods
        public new bool Equals(object Lhs, object Rhs)
        {
            if (Lhs == null || Rhs == null) return false;

            return Lhs.Equals(Rhs);
        }

        public int GetHashCode(object x)
        {
            if (x == null) throw new ArgumentNullException("x"); 

            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader Reader, string[] Names, object Owner)
        {

            var StringToDecrypt = NHibernateUtil.String.NullSafeGet(Reader, Names[0]);
            Salt = (string)NHibernateUtil.String.NullSafeGet(Reader, Names[1]);
             
            var DecryptorToUse = new CryptographyFactory().CreateDecryptor();
            return DecryptorToUse.Decrypt((string)StringToDecrypt, Salt);                        
        }

        public void NullSafeSet(IDbCommand Cmd, object Value, int Index)
        {
            if (Value == null)
            {
                NHibernateUtil.String.NullSafeSet(Cmd, null, Index);
                NHibernateUtil.String.NullSafeSet(Cmd, null, ++Index);
                return;
            }

            var UnencryptedMsg = (string) Value;
            var Factory = new CryptographyFactory();
            var EncryptorToUse = Factory.CreateEncryptor();

            if (string.IsNullOrEmpty(Salt))
                Salt = EncryptorToUse.GenerateSalt();

            var EncryptedMsg = EncryptorToUse.Encrypt(UnencryptedMsg, Salt);

            ////Set the values to persist
            NHibernateUtil.String.NullSafeSet(Cmd, EncryptedMsg, Index); //Save encrypted value
            NHibernateUtil.String.NullSafeSet(Cmd, Salt, ++Index); //Save Salt

        }

        public object DeepCopy(object Value)
        {
            return Value;
        }

        public object Replace(object Original, object Target, object Owner)
        {
            return Original;
        }

        public object Assemble(object Cached, object Owner)
        {
            return DeepCopy(Cached);
        }

        public object Disassemble(object Value)
        {
            return DeepCopy(Value);
        }
        #endregion



        #region Protected Properties
        /// <summary>
        /// Holds the salt value.
        /// </summary>
        private string Salt { get; set; }
        #endregion

    }

}