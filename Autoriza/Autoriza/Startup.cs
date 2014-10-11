using System;
using System.Reflection;
using System.Web.Mvc;
using Autoriza.DAO;
using Autoriza.Domain;
using Autoriza.Infra.FluentValidation;
using Autoriza.Infra.NHibernate;
using Autoriza.Jobs;
using FluentValidation;
using FluentValidation.Mvc;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using NHibernate;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.Mvc.FilterBindingSyntax;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autoriza.Startup))]
namespace Autoriza
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNinjectMiddleware(CreateKernel);

            app.UseHangfire(config =>
            {
                config.UseSqlServerStorage(
                    @"Data Source=G1711MAX\sqlexpress;Password=chapado;User ID=sa;Initial Catalog=autoriza;Application Name=Autoriza;");
                config.UseServer();
                config.UseNinjectActivator(CreateKernel());
            });

            RecurringJob.AddOrUpdate<VerificaSistemaOnline>(online => online.Verifica(), Cron.Minutely);
        }

        private StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            NinjectValidatorFactory ninjectValidatorFactory = new NinjectValidatorFactory(kernel);
            FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = ninjectValidatorFactory);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                           .ForEach(match => kernel.Bind(match.InterfaceType)
                                                   .To(match.ValidatorType));

            kernel.Bind<SistemaDAO>().To<SistemaDAO>();
            kernel.Bind<PermissaoDAO>().To<PermissaoDAO>();
            kernel.Bind<PerfilDAO>().To<PerfilDAO>();

            kernel.Bind<VerificaSistemaOnline>().To<VerificaSistemaOnline>();

            kernel.Bind<PermissoesDoPerfil>().To<PermissoesDoPerfil>();

            kernel.Bind<ISessionFactory>().ToProvider<SessionFactoryProvider>().InSingletonScope();
            kernel.Bind<ISession>().ToMethod(context => kernel.Get<ISessionFactory>().OpenSession()).InRequestScope();


            kernel.BindFilter<TransactionFilter>(FilterScope.Action, 0)
                .WhenActionMethodHas<TransactionAttribute>();

            return kernel;
        }

    }
}
