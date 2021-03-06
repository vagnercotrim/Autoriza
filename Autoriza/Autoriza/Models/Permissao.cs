﻿using System;
using System.Collections.Generic;

namespace Autoriza.Models
{
    public class Permissao
    {
        public virtual int Id { get; set; }

        public virtual String Nome { get; set; }

        public virtual String Descricao { get; set; }

        public virtual Sistema Sistema { get; set; }

        public virtual IList<Perfil> Perfis { get; set; }

        public override string ToString()
        {
            return String.Format("[Nome={0}]", Nome);
        }

    }
}