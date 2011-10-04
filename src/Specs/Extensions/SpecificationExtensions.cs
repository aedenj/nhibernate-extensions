using System;
using NUnit.Framework;



namespace NHibernateExtensions.Specs
{
    /// <summary>
    /// Provides BDD-style assertations for object references.
    /// </summary>
    public static class SpecificationExtensions
    {

        /// <summary>
        /// Verifies that the object reference is false.
        /// </summary>
        /// <param name="Actual">The reference to verify.</param>
        public static void ShouldBeFalse(this bool Actual)
        {
            Assert.IsFalse(Actual);
        }


        /// <summary>
        /// Verifies that the object reference is false.
        /// </summary>
        /// <param name="Actual">The reference to verify.</param>
        public static void ShouldBeTrue(this bool Actual)
        {
            Assert.IsTrue(Actual);
        }



        /// <summary>
        /// Verifies that the object reference is null.
        /// </summary>
        /// <param name="Actual">The reference to verify.</param>
        public static void ShouldBeNull(this object Actual)
        {
            Assert.IsNull(Actual);
        }



        /// <summary>
        /// Verifies that the object reference is not null.
        /// </summary>
        /// <param name="Actual">The reference to verify.</param>
        public static void ShouldNotBeNull(this object Actual)
        {
            Assert.IsNotNull(Actual);

        }



        /// <summary>
        /// Verifies that two objects are equal.
        /// </summary>
        /// <param name="Actual">The Actual object.</param>
        /// <param name="Expected">The Expected object.</param>
        public static void ShouldEqual(this object Actual, object Expected)
        {
            Assert.AreEqual(Expected, Actual);

        }



        /// <summary>
        /// Verifies that two objects are not equal.
        /// </summary>
        /// <param name="Actual">The Actual object.</param>
        /// <param name="NotExpected">The unexpected object.</param>
        public static void ShouldNotEqual(this object Actual, object NotExpected)
        {
            Assert.AreNotEqual(NotExpected, Actual);
        }



        /// <summary>
        /// Verifies that two objects are the same instance.
        /// </summary>
        /// <param name="Actual">The Actual object.</param>
        /// <param name="Expected">The Expected object.</param>
        public static void ShouldBeTheSameAs(this object Actual, object Expected)
        {
            Assert.AreSame(Expected, Actual);
        }



        /// <summary>
        /// Verifies that two objects are not the same instance.
        /// </summary>
        /// <param name="Actual">The Actual object.</param>
        /// <param name="NotExpected">The unexpected object.</param>
        public static void ShouldNotBeTheSameAs(this object Actual, object NotExpected)
        {
            Assert.AreNotSame(NotExpected, Actual);
        }



        /// <summary>
        /// Verifies that an object is of a specific type.
        /// </summary>
        /// <param name="Actual">The Actual object.</param>
        /// <param name="Expected">The Expected type.</param>
        public static void Is(this object Actual, Type Expected)
        {
            Assert.IsInstanceOf(Expected, Actual);
        }



        /// <summary>
        /// Verifies that an object is not a specific type.
        /// </summary>
        /// <param name="Actual">The Actual object.</param>
        /// <param name="NotExpected"></param>
        public static void IsNot(this object Actual, Type NotExpected)
        {
            Assert.IsNotInstanceOf(NotExpected, Actual);

        }

    }


}


