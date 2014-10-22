using Autoriza.Models;

namespace Autoriza.Domain
{
    public class Autenticador
    {

        public bool Verifica(Usuario usuario)
        {
            return usuario.Login == "vagner" && usuario.Senha == "123";
        }

    }
}