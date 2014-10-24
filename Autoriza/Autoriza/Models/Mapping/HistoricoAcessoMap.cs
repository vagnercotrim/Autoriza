using FluentNHibernate.Mapping;

namespace Autoriza.Models.Mapping
{
    public class HistoricoAcessoMap : ClassMap<HistoricoAcesso>
    {

        public HistoricoAcessoMap()
        {
            Id(h => h.Id);

            Map(h => h.Data);
            Map(h => h.Ip);
            Map(h => h.Navegador);

            References(h => h.Usuario);
            References(h => h.Sistema);
        }

    }
}