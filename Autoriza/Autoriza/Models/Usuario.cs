using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}