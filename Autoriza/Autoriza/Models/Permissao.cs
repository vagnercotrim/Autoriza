﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Models
{
    public class Permissao
    {
        public virtual int Id { get; set; }

        public virtual String Nome { get; set; }

        public virtual String Descricao { get; set; }

    }
}