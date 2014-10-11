using System.Web.Mvc;
using Autoriza.DAO;
using Autoriza.Domain;
using Autoriza.Infra.FluentValidation;
using Autoriza.Infra.NHibernate;
using Autoriza.Jobs;
using FluentValidation;
using FluentValidation.Mvc;
using NHibernate;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc.FilterBindingSyntax;
using System.Reflection;

namespace Autoriza.Infra.NInject
{
    public class StandardKernelCreator
    {

        public StandardKernel CreateStandardKernel()
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