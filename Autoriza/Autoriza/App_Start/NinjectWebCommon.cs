[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Autoriza.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Autoriza.NinjectWebCommon), "Stop")]

namespace Autoriza
{
    using Domain;
    using Infra.NInject;
    using Jobs;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new FluentValidationModule(), new NHibernateModule(), new DAOModule());

            kernel.Bind<VerificaSistemaOnline>().To<VerificaSistemaOnline>();

            kernel.Bind<PermissoesDoPerfil>().To<PermissoesDoPerfil>();
            kernel.Bind<Autenticador>().To<Autenticador>();
        }
    }
}
