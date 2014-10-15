using Autoriza.DAO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.Models.Validation
{
    public class PermissaoValidation : AbstractValidator<Permissao>
    {
        private PermissaoDAO dao;

        public PermissaoValidation(PermissaoDAO dao)
        {
            this.dao = dao;

            RuleFor(permissao => permissao.Nome).NotEmpty();
            RuleFor(permissao => permissao.Descricao).NotEmpty();

            RuleFor(permissao => permissao.Nome).Must((permissao, nome) => NomeDisponivel(permissao)).WithMessage("Este nome já está em uso.");
        }

        private bool NomeDisponivel(Permissao permissao)
        {
            Permissao noBanco = dao.FindByNome(permissao.Sistema.Id, permissao.Nome);

            if (noBanco == null)
                return true;

            if (permissao.Id == noBanco.Id)
                return true;

            if (permissao.Nome != noBanco.Nome)
                return true;

            return false;
        }

    }
}