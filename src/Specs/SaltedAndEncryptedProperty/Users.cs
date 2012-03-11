namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty
{
    static class Users
    {
        public static int Count()
        {
            return QueryHelper.ExecuteScalarQuery<int>("SELECT COUNT(*) FROM Users");
        }

        public const string SaltOfFirstUser = @"SELECT TOP 1 Salt FROM Users";
        public const string PasswordOfFirstUser = @"SELECT TOP 1 Password FROM Users";

    }
}
