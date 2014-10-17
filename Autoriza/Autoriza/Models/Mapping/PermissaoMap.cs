using FluentNHibernate.Mapping;

namespace Autoriza.Models.Mapping
{
    public class PermissaoMap : ClassMap<Permissao>
    {

        public PermissaoMap()
        {
            Id(x => x.Id);

            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Descricao).Not.Nullable();

            References(x => x.Sistema).Not.Nullable();

            HasManyToMany(x => x.Perfis);
        }

    }
}