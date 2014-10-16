using Autoriza.Models.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Autoriza.Infra.NHibernate
{
    public class SessionFactoryCreator
    {

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        @"Data Source=G1711MAX\sqlexpress;Password=chapado;User ID=sa;Initial Catalog=autoriza;Application Name=Autoriza;")
                        .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SistemaMap>())
                //.ExposeConfiguration(c => new SchemaExport(c).Create(false, true)) // TODO Remover depois de definir todos os models
                .BuildSessionFactory();
        }

    }
}