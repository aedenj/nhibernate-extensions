﻿using System.Data.SqlServerCe;
using NHibernateExtensions.Specs.Properties;

namespace NHibernateExtensions.Specs.SaltedAndEncryptedProperty {
  internal static class QueryHelper {
    public static T ExecuteQuery<T>(string Query) {
      T NumberOfRows;
      using (var Connection = new SqlCeConnection(Settings.Default.NHibernateExtensionsConnectionString)) {
        using (var Cmd = new SqlCeCommand(Query, Connection)) {
          Cmd.Connection.Open();
          NumberOfRows = (T) Cmd.ExecuteScalar();
        }
      }

      return NumberOfRows;
    }

    public static void ExecuteCommand(string Query, string[] Parameters, string[] Values) {
      using (var Connection = new SqlCeConnection(Settings.Default.NHibernateExtensionsConnectionString)) {
        using (var Cmd = new SqlCeCommand(Query, Connection)) {
          for (var P = 0; P < Parameters.Length; P++) {
            Cmd.Parameters.AddWithValue(Parameters[P], Values[P]);
          }

          Cmd.Connection.Open();
          Cmd.ExecuteNonQuery();
        }
      }
    }
  }
}