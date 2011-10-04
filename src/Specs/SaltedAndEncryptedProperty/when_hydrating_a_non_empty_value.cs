using NUnit.Framework;

using NHibernateExtensions.SaltedAndEncryptedProperty;



namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty
{
    [TestFixture("SomeStringThatReallyNeedsEncryption")]
    [TestFixture("Don't Leave Me Out")]
    [TestFixture("a")]
    [TestFixture("")]
    public class when_hydrating_a_non_empty_value : PersistenceContext
    {
        #region scenario specific setup
        private SaltedEncryptedString TestType;
        private readonly EntityWithEncryptedProperty UnpersistedEntity;
        private EntityWithEncryptedProperty RetreivedEntity;
        private Decryptor Decryptor;


        public when_hydrating_a_non_empty_value(string UnencryptedMessage)
        {
            UnpersistedEntity = new EntityWithEncryptedProperty { EncryptedProperty = UnencryptedMessage };
        }


        protected override void Context()
        {
            base.Context();

            TestType = new SaltedEncryptedString();
            Decryptor = new CryptographyFactory().CreateDecryptor();

            CurrentSession.Save(UnpersistedEntity);
        }
        #endregion


        protected override void BecauseOf()
        {
            RetreivedEntity = CurrentSession.Load<EntityWithEncryptedProperty>(UnpersistedEntity.Id);
        }


        [Test]
        public void then_returned_value_is_a_string()
        {
            TestType.ReturnedType.ShouldEqual(typeof(string));
        }


        [Test]
        public void then_the_original_value_is_the_value_of_the_property_on_the_hydrated_object()
        {
            Decryptor.Decrypt(EncryptedValue(), Salt()).ShouldEqual(RetreivedEntity.EncryptedProperty);
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