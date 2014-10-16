﻿using System;

namespace Autoriza.Models
{
    public class Usuario
    {

        public virtual int Id { get; set; }

        public virtual String Login { get; set; }

        public virtual String Senha { get; set; }

        public virtual String Email { get; set; }

        public virtual bool Ativo { get; set; }
        
        public override string ToString()
        {
            return String.Format("[Login={0}]", Login);
        }

        public Usuario()
        {
            Ativo = true;
        }

    }
}