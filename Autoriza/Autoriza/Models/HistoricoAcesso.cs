using System;

namespace Autoriza.Models
{
    public class HistoricoAcesso
    {

        public virtual int Id { get; set; }

        public virtual DateTime Data { get; set; }

        public virtual String Ip { get; set; }

        public virtual String Navegador { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Sistema Sistema { get; set; }

        public static HistoricoAcesso Novo(Usuario usuario, Sistema sistema, String ip, String navegador)
        {
            return new HistoricoAcesso
            {
                Usuario = usuario,
                Sistema = sistema,
                Data = DateTime.Now,
                Ip = ip,
                Navegador = navegador
            };
        }

    }
}