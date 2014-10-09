using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Models.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.Id);
            Map(x => x.Login).Not.Nullable().Unique();
            Map(x => x.Senha).Not.Nullable();
            Map(x => x.Email).Not.Nullable().Unique();
            Map(x => x.Ativo).Not.Nullable();
        }
    }
}