using System.Linq;
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
            perfil.Permissoes = ArrayToEnumerable(permissoes).ToList();

            _perfilDao.Update(perfil);
        }

        private IEnumerable<Permissao> ArrayToEnumerable(int[] permissoes)
        {
            if (permissoes != null)
                foreach (var id in permissoes)
                    yield return _permissaoDao.Get(id);
        }

    }
}