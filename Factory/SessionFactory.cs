using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MovieRevenue.Factory.Entity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRevenue
{
    class SessionFactory
    {
        public static ISession OpenSession()
        {
            try
            {
                ISessionFactory sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(@"Server=localhost\MSSQLSERVER01;Database=master;Trusted_Connection=True;"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Movie>())
                    .BuildSessionFactory();
                return sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
