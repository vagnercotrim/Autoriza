using Autoriza.DAO;
using Autoriza.Models;
using System.Collections.Generic;

namespace Autoriza.Domain
{
    public class PermissoesDoPerfil
    {

        private readonly PerfilDAO _perfilDao;
        private readonly PermissaoDAO _permissaoDao;

        public PermissoesDoPerfil(PerfilDAO perfilDao, PermissaoDAO permissaoDao)
        {
            _perfilDao = perfilDao;
            _permissaoDao = permissaoDao;
        }

        public void Atualizar(Perfil perfil, int[] permissoes)
        {
            IList<Permissao> permissoesList = new List<Permissao>();

            if (permissoes != null)
                foreach (var id in permissoes)
                    permissoesList.Add(_permissaoDao.Get(id));

            perfil.Permissoes = permissoesList;

            _perfilDao.Update(perfil);
        }

    }
}