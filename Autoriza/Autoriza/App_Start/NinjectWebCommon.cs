using Autoriza.DAO;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Autoriza.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Autoriza.NinjectWebCommon), "Stop")]

namespace Autoriza
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using NHibernate;
    using Autoriza.Infra.NHibernate;
    using Autoriza.Infra.FluentValidation;
    using FluentValidation.Mvc;
    using FluentValidation;
    using System.Reflection;
    using Ninject.Web.Mvc.FilterBindingSyntax;
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

            kernel.Bind<ISessionFactory>().ToProvider<SessionFactoryProvider>().InSingletonScope();
            kernel.Bind<ISession>().ToMethod(context => kernel.Get<ISessionFactory>().OpenSession()).InRequestScope();
        }
    }
}
