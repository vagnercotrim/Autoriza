using Autoriza.DAO;
using Ninject.Modules;

namespace Autoriza.Infra.NInject
{
    public class DAOModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<SistemaDAO>().To<SistemaDAO>();
            Kernel.Bind<PermissaoDAO>().To<PermissaoDAO>();
            Kernel.Bind<PerfilDAO>().To<PerfilDAO>();
            Kernel.Bind<UsuarioDAO>().To<UsuarioDAO>();
        }
    }
}