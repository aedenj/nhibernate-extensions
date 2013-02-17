using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateExtensions.Specs {
    internal static class NHibernate {
        internal static void Setup() {
            var DatabaseConfig =
                MsSqlCeConfiguration.Standard
                    .ConnectionString("Data Source=NHibernateExtensions.sdf");

            Action<MappingConfiguration> Mappings =
                m => m.FluentMappings
                      .AddFromAssemblyOf<User>()
                      .Conventions.Add(Table.Is(x => x.EntityType.Name + "s"), DefaultCascade.All(), DefaultLazy.Never());

            var FluentConfig =
                Fluently.Configure()
                    .Database(DatabaseConfig)
                    .Mappings(Mappings)                    
                    .ExposeConfiguration(SetupDatabaseSchema)
                    .ExposeConfiguration(c => c.SetProperty("connection.release_mode", "on_close"))
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "call"));

            SessionFactory = FluentConfig.BuildSessionFactory();            
        }

        private static Action<Configuration> SetupDatabaseSchema {
            get
            {
                return delegate (Configuration Config)
                {
                    var Schema = new SchemaExport(Config);
                    Schema.Drop(false, true);
                    Schema.Create(false, true);
                };
            }
        }

        public static ISession GetCurrentSession() {
            var Current = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(Current);
            return Current;
        }

        public static void CloseSession() {
            var Session = CurrentSessionContext.Unbind(SessionFactory);
            Session.Dispose();
        }

        private static ISessionFactory SessionFactory;
    }

}