using Autoriza.Models;

namespace Autoriza.Domain
{
    public class Autenticador
    {

        private Usuario _usuario;

        public Autenticador(Usuario usuario)
        {
            _usuario = usuario;
        }

    }
}