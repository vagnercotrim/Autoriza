using Autoriza.DAO;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Autoriza.Infra.NInject
{
    public class DAOModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<SistemaDAO>().To<SistemaDAO>().InRequestScope();
            Kernel.Bind<PermissaoDAO>().To<PermissaoDAO>().InRequestScope();
            Kernel.Bind<PerfilDAO>().To<PerfilDAO>().InRequestScope();
            Kernel.Bind<UsuarioDAO>().To<UsuarioDAO>().InRequestScope();
        }
    }
}