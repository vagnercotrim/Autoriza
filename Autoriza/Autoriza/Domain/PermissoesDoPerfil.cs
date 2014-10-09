using Autoriza.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Domain
{
    public class PermissoesDoPerfil
    {

        private readonly PerfilDAO perfilDAO;
        private readonly PermissaoDAO permissaoDAO;

        public PermissoesDoPerfil(PerfilDAO perfilDAO, PermissaoDAO permissaoDAO)
        {
            this.perfilDAO = perfilDAO;
            this.permissaoDAO = permissaoDAO;
        }


        
    }
}