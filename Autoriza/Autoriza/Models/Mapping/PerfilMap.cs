using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Models.Mapping
{
    public class PerfilMap : ClassMap<Perfil>
    {

        public PerfilMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Descricao).Not.Nullable();
        }

    }
}