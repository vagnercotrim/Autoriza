using Autoriza.DAO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Models.Validation
{
    public class PerfilValidation : AbstractValidator<Perfil>
    {

        private PerfilDAO PerfilDAO;

        public PerfilValidation(PerfilDAO perfilDAO)
        {
            PerfilDAO = perfilDAO;

            RuleFor(s => s.Nome).NotEmpty();
            RuleFor(s => s.Descricao).NotEmpty();
        }

        // TODO Verificar se já existe um perfil com o mesmo nome para o sistema.

    }
}