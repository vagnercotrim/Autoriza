﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Models.Mapping
{
    public class SistemaMap : ClassMap<Sistema>
    {

        public SistemaMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome).Length(100).Not.Nullable();
        }

    }
}