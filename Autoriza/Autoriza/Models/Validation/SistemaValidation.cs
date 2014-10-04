using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace Autoriza.Models.Validation
{
    public class SistemaValidation : AbstractValidator<Sistema>
    {

        public SistemaValidation()
        {
            RuleFor(s => s.Nome).NotEmpty();
        }

    }
}