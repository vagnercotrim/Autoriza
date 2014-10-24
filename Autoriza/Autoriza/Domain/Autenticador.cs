using Autoriza.DAO;
using Autoriza.Models;

namespace Autoriza.Domain
{
    public class Autenticador
    {

        private UsuarioDAO _usuarioDao;

        public Autenticador(UsuarioDAO usuarioDao)
        {
            _usuarioDao = usuarioDao;
        }

        public bool Verifica(Usuario usuario)
        {
            usuario = _usuarioDao.FindByLoginESenha(usuario);

            return usuario != null;
        }

    }
}