using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Models.Validation
{
    public class PermissaoValidation : AbstractValidator<Permissao>
    {
        public PermissaoValidation()
        {
            RuleFor(s => s.Nome).NotEmpty();
            RuleFor(s => s.Descricao).NotEmpty();
        }

        // TODO Verificar se já existe uma permissão com o mesmo nome para o sistema.

    }
}