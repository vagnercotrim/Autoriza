using System.Web.Mvc;
using Autoriza.Infra.NHibernate;
using NHibernate;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Mvc.FilterBindingSyntax;

namespace Autoriza.Infra.NInject
{
    public class NHibernateModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ISessionFactory>().ToProvider<SessionFactoryProvider>().InSingletonScope();
            Kernel.Bind<ISession>().ToMethod(context => Kernel.Get<ISessionFactory>().OpenSession()).InRequestScope();

            Kernel.BindFilter<TransactionFilter>(FilterScope.Action, 0).WhenActionMethodHas<TransactionAttribute>();
        }
    }
}