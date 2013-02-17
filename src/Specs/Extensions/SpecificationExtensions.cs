using System;
using NUnit.Framework;

namespace NHibernateExtensions.Specs {
    public static class SpecificationExtensions {
        public static void ShouldBeFalse(this bool Actual) {
            Assert.IsFalse(Actual);
        }

        public static void ShouldBeTrue(this bool Actual) {
            Assert.IsTrue(Actual);
        }

        public static void ShouldBeNull(this object Actual) {
            Assert.IsNull(Actual);
        }

        public static void ShouldNotBeNull(this object Actual) {
            Assert.IsNotNull(Actual);
        }

        public static void ShouldEqual(this object Actual, object Expected) {
            Assert.AreEqual(Expected, Actual);
        }

        public static void ShouldNotEqual(this object Actual, object NotExpected) {
            Assert.AreNotEqual(NotExpected, Actual);
        }

        public static void ShouldBeTheSameAs(this object Actual, object Expected) {
            Assert.AreSame(Expected, Actual);
        }

        public static void ShouldNotBeTheSameAs(this object Actual, object NotExpected) {
            Assert.AreNotSame(NotExpected, Actual);
        }

        public static void Is(this object Actual, Type Expected) {
            Assert.IsInstanceOf(Expected, Actual);
        }

        public static void IsNot(this object Actual, Type NotExpected) {
            Assert.IsNotInstanceOf(NotExpected, Actual);
        }
    }
}


