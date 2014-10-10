using System;
using System.Collections.Generic;
using Autoriza.Models.Validation;
using FluentValidation.Attributes;
using Autoriza.Infra;

namespace Autoriza.Models
{

    [Validator(typeof (SistemaValidation))]
    public class Sistema
    {

        public virtual int Id { get; set; }

        public virtual String Nome { get; set; }

        public virtual String Url { get; set; }

        public virtual String ChaveAcesso { get; set; }
        
        public virtual IList<Perfil> Perfis { get; set; }

        public virtual IList<Permissao> Permissoes { get; set; }

        public Sistema()
        {
            Randomize random = new Randomize();
            ChaveAcesso = random.Generate(15);
        }
        
    }
}