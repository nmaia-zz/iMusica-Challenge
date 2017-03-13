using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Project.Infra.Mapping;
using System.Configuration;

namespace Project.Infra.Util
{
    public class HibernateUtil
    {
        //using singleton concept for the session factory
        private static ISessionFactory factory;

        public static ISessionFactory GetSessionFactory()
        {
            if (factory == null)
            {
                factory = Fluently.Configure().Database(
                    MsSqlConfiguration.MsSql2012
                        .ConnectionString(ConfigurationManager
                            .ConnectionStrings["connString"].ConnectionString))
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DependentMap>())
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RoleMap>())
                                    .BuildSessionFactory();
            }

            return factory;
        }
    }
}
