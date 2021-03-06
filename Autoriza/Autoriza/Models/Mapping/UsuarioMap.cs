﻿using FluentNHibernate.Mapping;

namespace Autoriza.Models.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.Id);

            Map(x => x.Nome).Not.Nullable().Unique();
            Map(x => x.Login).Not.Nullable().Unique();
            Map(x => x.Senha).Not.Nullable();
            Map(x => x.Email).Not.Nullable().Unique();
            Map(x => x.Ativo).Not.Nullable();
            Map(x => x.DataAlteracao).Not.Nullable();

            HasManyToMany(x => x.Perfis);
        }
    }
}