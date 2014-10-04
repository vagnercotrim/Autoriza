using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Ninject.Activation;

namespace Autoriza.Infra.NHibernate
{
    public class SessionFactoryProvider : Provider<ISessionFactory>
    {
        protected override ISessionFactory CreateInstance(IContext context)
        {
            var sessionFactory = new SessionFactory();
            
            return sessionFactory.CreateSessionFactory();
        }
    }
}