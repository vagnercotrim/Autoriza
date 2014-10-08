﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Models
{
    public class Perfil
    {

        public virtual int Id { get; set; }

        public virtual String Nome { get; set; }

        public virtual String Descricao { get; set; }

        public virtual Sistema Sistema { get; set; }

    }
}