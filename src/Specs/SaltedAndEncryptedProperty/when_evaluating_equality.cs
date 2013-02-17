using NUnit.Framework;
using NHibernateExtensions.SaltedAndEncryptedProperty;

namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty {
  [TestFixture]
  public class when_evaluating_equality {
    private SaltedEncryptedString TestType;
    private const string X = "TestString";
    private const string ReferenceToX = X;
    private const string Y = "TestString";
    private const string Z = "TestString";

    [SetUp]
    public void SetUp() {
      TestType = new SaltedEncryptedString();
    }

    [Test]
    public void then_reflexivity_holds() {
      TestType.Equals(X, X).ShouldBeTrue();
    }

    [Test]
    public void then_symmetric_with_respect_to_reference() {
      TestType.Equals(X, ReferenceToX).ShouldBeTrue();
      TestType.Equals(ReferenceToX, X).ShouldBeTrue();
    }

    [Test]
    public void then_symmetric_with_respect_to_value() {
      TestType.Equals(X, Y).ShouldBeTrue();
      TestType.Equals(Y, X).ShouldBeTrue();
    }

    [Test]
    public void then_transitivity_holds() {
      TestType.Equals(X, Y).ShouldBeTrue();
      TestType.Equals(Y, Z).ShouldBeTrue();
      TestType.Equals(X, Z).ShouldBeTrue();
    }

    [Test]
    public void then_comparison_with_null_is_false() {
      Assert.IsFalse(TestType.Equals(X, null));
      Assert.IsFalse(TestType.Equals(null, null));
    }
  }
}