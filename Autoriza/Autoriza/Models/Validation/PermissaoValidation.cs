using Autoriza.DAO;
using FluentValidation;

namespace Autoriza.Models.Validation
{
    public class PermissaoValidation : AbstractValidator<Permissao>
    {
        private readonly PermissaoDAO _dao;

        public PermissaoValidation(PermissaoDAO dao)
        {
            _dao = dao;

            RuleFor(permissao => permissao.Nome).NotEmpty();
            RuleFor(permissao => permissao.Descricao).NotEmpty();

            RuleFor(permissao => permissao.Nome).Must((permissao, nome) => NomeDisponivel(permissao)).WithMessage("Este nome já está em uso.");
        }

        private bool NomeDisponivel(Permissao permissao)
        {
            Permissao noBanco = _dao.FindByNome(permissao.Sistema.Id, permissao.Nome);

            if (noBanco == null)
                return true;

            return noBanco.Id == permissao.Id;
        }

    }
}