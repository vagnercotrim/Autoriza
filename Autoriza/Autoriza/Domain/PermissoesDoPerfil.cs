using Autoriza.DAO;
using Autoriza.Models;
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

        public void Atualizar(Perfil perfil, int[] permissoes)
        {
            IList<Permissao> permissoesList = new List<Permissao>();

            if(permissoes != null)
            foreach (var id in permissoes)
                permissoesList.Add(permissaoDAO.Get(id));
            
            perfil.Permissoes = permissoesList;

            perfilDAO.Update(perfil);
        }
        
    }
}