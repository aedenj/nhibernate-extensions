using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty
{
    public class PersistenceContext : ContextSpecification
    {
        private ISessionFactory SessionFactory;
        protected ISession CurrentSession;


        protected override void Context()
        {
            base.Context();
            
            SessionFactory = new Configuration().Configure().BuildSessionFactory();
            CurrentSession = SessionFactory.OpenSession();            
            CurrentSessionContext.Bind(CurrentSession);            
        }


        protected override void CleanUpContext()
        {
            base.CleanUpContext();

            CurrentSessionContext.Unbind(SessionFactory);
            CurrentSession.Dispose();
        }
    }
}