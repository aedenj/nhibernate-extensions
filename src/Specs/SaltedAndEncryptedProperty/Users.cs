namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty {
  internal static class Users {
    public const string SaltOfFirstUser = @"SELECT TOP 1 Salt FROM Users";
    public const string PasswordOfFirstUser = @"SELECT TOP 1 Password FROM Users";

    public static int Count() {
      return QueryHelper.ExecuteQuery<int>("SELECT COUNT(*) FROM Users");
    }
  }
}