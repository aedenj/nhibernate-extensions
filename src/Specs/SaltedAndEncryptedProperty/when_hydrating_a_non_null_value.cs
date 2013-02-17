using NUnit.Framework;
using NHibernateExtensions.SaltedAndEncryptedProperty;

namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty {
  [TestFixture("SomeStringThatReallyNeedsEncryption")]
  [TestFixture("Don't Leave Me Out")]
  [TestFixture("a")]
  [TestFixture("")]
  public class when_hydrating_a_non_null_value : PersistenceContext {
    private SaltedEncryptedString TestType;
    private readonly User UnpersistedEntity;
    private User RetreivedEntity;
    private Decryptor Decryptor;

    public when_hydrating_a_non_null_value(string UnencryptedMessage) {
      UnpersistedEntity = new User {Password = UnencryptedMessage};
    }

    protected override void Context() {
      base.Context();

      TestType = new SaltedEncryptedString();
      Decryptor = new CryptographyFactory().CreateDecryptor();

      CurrentSession.Save(UnpersistedEntity);
    }

    protected override void BecauseOf() {
      RetreivedEntity = CurrentSession.Load<User>(UnpersistedEntity.Id);
    }

    [Test]
    public void then_returned_value_is_a_string() {
      TestType.ReturnedType.ShouldEqual(typeof (string));
    }

    [Test]
    public void then_the_original_value_is_the_value_of_the_property_on_the_hydrated_object() {
      Decryptor.Decrypt(EncryptedValue(), Salt()).ShouldEqual(RetreivedEntity.Password);
    }

    private static string Salt() {
      return QueryHelper.ExecuteQuery<string>(Users.SaltOfFirstUser);
    }

    private static string EncryptedValue() {
      return QueryHelper.ExecuteQuery<string>(Users.PasswordOfFirstUser);
    }
  }
}