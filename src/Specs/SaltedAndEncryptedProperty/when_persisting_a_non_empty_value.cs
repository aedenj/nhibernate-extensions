using System.Data;
using NUnit.Framework;

using NHibernateExtensions.SaltedAndEncryptedProperty;



namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty
{
    //Parameters: Unencrypted Message
    [TestFixture("SomeStringThatReallyNeedsEncryption")]
    [TestFixture("Don't Leave Me Out")]
    [TestFixture("a")]
    public class when_persisting_a_non_empty_value : PersistenceContext
    {
        #region scenario specific setup
        private SaltedEncryptedString TestType;
        private Encryptor Encryptor;

        private readonly EntityWithEncryptedProperty UnpersistedEntity;


        public when_persisting_a_non_empty_value(string UnencryptedMessage)
        {

            UnpersistedEntity = new EntityWithEncryptedProperty { EncryptedProperty = UnencryptedMessage };
        }

        protected override void Context()
        {
            base.Context();

            TestType = new SaltedEncryptedString();
            Encryptor = new CryptographyFactory().CreateEncryptor();
        }
        #endregion


        protected override void BecauseOf()
        {            
            CurrentSession.Save(UnpersistedEntity);
        }


        [Test]
        public void then_the_salt_and_message_are_stored_as_strings()
        {
            TestType.SqlTypes[0].DbType.ShouldEqual(DbType.String);
            TestType.SqlTypes[1].DbType.ShouldEqual(DbType.String);
        }


        [Test]
        public void then_the_type_is_not_mutable()
        {
            TestType.IsMutable.ShouldBeFalse();
        }


        [Test]
        public void then_the_original_value_is_not_stored()
        {
            EncryptedValue().ShouldNotEqual(UnpersistedEntity.EncryptedProperty);
        }


        [Test]
        public void then_the_original_is_encrypted()
        {
            Encryptor.Encrypt(UnpersistedEntity.EncryptedProperty, Salt()).ShouldEqual(EncryptedValue());            
        }


        #region scenario helpers
        private static string Salt()
        {
            return QueryHelper.ExecuteScalarQuery<string>("SELECT Salt FROM EntityWithEncryptedProperty");
        }

        private static string EncryptedValue()
        {
            return QueryHelper.ExecuteScalarQuery<string>("SELECT Value FROM EntityWithEncryptedProperty");
        }
        #endregion
    }
}