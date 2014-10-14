[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Autoriza.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Autoriza.NinjectWebCommon), "Stop")]

namespace Autoriza
{
    using Autoriza.DAO;
    using Autoriza.Domain;
    using Autoriza.Infra.FluentValidation;
    using Autoriza.Infra.NHibernate;
    using Autoriza.Jobs;
    using FluentValidation;
    using FluentValidation.Mvc;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using NHibernate;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterFluentValidation(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterFluentValidation(IKernel kernel)
        {
            NinjectValidatorFactory ninjectValidatorFactory = new NinjectValidatorFactory(kernel);
            FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = ninjectValidatorFactory);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                           .ForEach(match => kernel.Bind(match.InterfaceType)
                                                   .To(match.ValidatorType));
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<SistemaDAO>().To<SistemaDAO>();
            kernel.Bind<PermissaoDAO>().To<PermissaoDAO>();
            kernel.Bind<PerfilDAO>().To<PerfilDAO>();

            kernel.Bind<VerificaSistemaOnline>().To<VerificaSistemaOnline>();

            kernel.Bind<PermissoesDoPerfil>().To<PermissoesDoPerfil>();

            kernel.Bind<ISessionFactory>().ToProvider<SessionFactoryProvider>().InSingletonScope();
            kernel.Bind<ISession>().ToMethod(context => kernel.Get<ISessionFactory>().OpenSession()).InRequestScope();
            
            kernel.BindFilter<TransactionFilter>(FilterScope.Action, 0)
                .WhenActionMethodHas<TransactionAttribute>();
        }
    }
}
