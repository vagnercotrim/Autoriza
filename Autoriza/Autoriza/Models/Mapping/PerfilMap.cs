using FluentNHibernate.Mapping;

namespace Autoriza.Models.Mapping
{
    public class PerfilMap : ClassMap<Perfil>
    {

        public PerfilMap()
        {
            Id(x => x.Id);
            
            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Descricao).Not.Nullable();

            References(x => x.Sistema);
            HasManyToMany(x => x.Permissoes);
        }

    }
}