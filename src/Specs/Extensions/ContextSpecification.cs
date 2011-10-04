using NUnit.Framework;

namespace NHibernateExtensions.Specs
{

    public abstract class ContextSpecification
    {
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            Context();

            BecauseOf();
        }


        [TestFixtureTearDown]
        protected void FixtureTearDown()
        {
            CleanUpContext();
        }



        protected virtual void Context() { }
        protected virtual void BecauseOf() { }
        protected virtual void CleanUpContext() { }
    }
}
