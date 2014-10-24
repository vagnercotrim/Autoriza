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

        public HistoricoAcesso(Usuario usuario, Sistema sistema, DateTime data, String ip, String navegador)
        {
            Usuario = usuario;
            Sistema = sistema;
            Data = data;
            Ip = ip;
            Navegador = navegador;
        }

    }
}