using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autoriza.Models;
using Autoriza.Models.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Autoriza.Infra.NHibernate
{
    public class SessionFactory
    {

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        @"Data Source=G1711MAX\sqlexpress;Password=chapado;User ID=sa;Initial Catalog=autoriza;Application Name=Autoriza;")
                        .ShowSql())
                .Mappings(m => m.FluentMappings.Add<SistemaMap>())
                .BuildSessionFactory();
        }

    }
}