using Autoriza.DAO;
using FluentValidation;

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

            if (permissao.Id == 0)
                return podeSalvar(permissao, noBanco);

            return podeAlterar(permissao, noBanco);
        }

        private bool podeAlterar(Permissao permissao, Permissao noBanco)
        {
            if (permissao.Id == noBanco.Id)
                return true;

            return !permissao.Nome.Equals(noBanco.Nome);
        }

        private bool podeSalvar(Permissao permissao, Permissao noBanco)
        {
            return !permissao.Nome.Equals(noBanco.Nome);
        }

    }
}