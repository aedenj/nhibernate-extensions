using NUnit.Framework;



namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty
{
    [TestFixture]
    public class when_persisting_null : PersistenceContext
    {
        #region scenario specific context setup
        private readonly User UnpersistedEntityWithNullProperty = new User { Password = null };
        #endregion


        protected override void BecauseOf()
        {
            CurrentSession.Save(UnpersistedEntityWithNullProperty);
        }

        [Test]
        public void then_a_row_is_inserted()
        {
            Users.Count().ShouldEqual(1);
        }



    }
}