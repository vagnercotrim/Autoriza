using System.Reflection;
using System.Web.Mvc;
using Autoriza.Infra.FluentValidation;
using Autoriza.Models.Validation;
using FluentValidation;
using FluentValidation.Mvc;
using Ninject.Modules;

namespace Autoriza.Infra.NInject
{
    public class FluentValidationModule : NinjectModule
    {
        public override void Load()
        {
            NinjectValidatorFactory ninjectValidatorFactory = new NinjectValidatorFactory(Kernel);
            FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = ninjectValidatorFactory);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                           .ForEach(match => Kernel.Bind(match.InterfaceType)
                                                   .To(match.ValidatorType));

            Kernel.Bind<PerfilValidation>().To<PerfilValidation>();
            Kernel.Bind<PermissaoValidation>().To<PermissaoValidation>();
        }
    }
}