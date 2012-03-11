using NHibernate;


namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty
{
    public class PersistenceContext : ContextSpecification
    {
        protected ISession CurrentSession;


        protected override void Context()
        {
            base.Context();

            NHibernate.Setup();
            CurrentSession = NHibernate.GetCurrentSession();
        }


        protected override void CleanUpContext()
        {
            base.CleanUpContext();

            NHibernate.CloseSession();
        }
    }
}