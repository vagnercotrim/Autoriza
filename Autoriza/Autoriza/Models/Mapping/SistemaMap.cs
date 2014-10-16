﻿using FluentNHibernate.Mapping;

namespace Autoriza.Models.Mapping
{
    public class SistemaMap : ClassMap<Sistema>
    {

        public SistemaMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Url).Not.Nullable();
            Map(x => x.ChaveIdentificacao).Not.Nullable();
            Map(x => x.ChaveAcesso).Not.Nullable();
            HasMany(x => x.Perfis);
            HasMany(x => x.Permissoes);
        }

    }
}