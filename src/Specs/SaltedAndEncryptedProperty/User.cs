using FluentNHibernate.Mapping;
using NHibernateExtensions.SaltedAndEncryptedProperty;

namespace NHibernateExtensions.Specs {
  public class User {
    public int Id { get; private set; }
    public string Username { get; set; }
    public string Password { get; set; }
  }

  public class UserMap : ClassMap<User> {
    public UserMap() {
      Not.LazyLoad();
      Id(x => x.Id);
      Map(x => x.Username);
      Map(x => x.Password).CustomType<SaltedEncryptedString>()
        .Columns.Add(new[] {"Password", "Salt"});
    }
  }
}