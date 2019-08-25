using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Helper
{
    public class FluentNHibernateHelper
    {
        #region properties

        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    try
                    {
                        _sessionFactory = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=./;Initial Catalog=WebAPI;Integrated Security=True"))
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Blog>())
                            .ExposeConfiguration(cfg =>
                            {
                                cfg.SetProperty("adonet.batch_size", "100");
                                cfg.SetProperty("command_timeout", (TimeSpan.FromMinutes(1).TotalSeconds.ToString()));
                                new SchemaUpdate(cfg).Execute(false, true);
                            })
                            .BuildSessionFactory();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                }

                return _sessionFactory;
            }
        }

        #endregion

        #region Method

        public static IRepository GetRepository()
        {
            return new Repository(SessionFactory.OpenSession(new Interceptor()));
        }

        #endregion
    }
}