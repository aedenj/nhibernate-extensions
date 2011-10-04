using NUnit.Framework;



namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty
{
    [TestFixture]
    public class when_persisting_null : PersistenceContext
    {
        #region scenario specific context setup
        private readonly EntityWithEncryptedProperty UnpersistedEntityWithNullProperty = new EntityWithEncryptedProperty { EncryptedProperty = null };
        #endregion


        protected override void BecauseOf()
        {
            CurrentSession.Save(UnpersistedEntityWithNullProperty);
        }

        [Test]
        public void then_a_row_is_inserted()
        {
            CurrentNumberOfRowsInDb().ShouldEqual(1);
        }


        #region scenario helpers
        private static int CurrentNumberOfRowsInDb()
        {
            return QueryHelper.ExecuteScalarQuery<int>("SELECT COUNT(*) FROM EntityWithEncryptedProperty");
        }
        #endregion
    }
}