using Autoriza.DAO;
using FluentValidation;

namespace Autoriza.Models.Validation
{
    public class SistemaValidation : AbstractValidator<Sistema>
    {

        private SistemaDAO dao;

        public SistemaValidation(SistemaDAO dao)
        {
            this.dao = dao;

            RuleFor(sistema => sistema.Nome).NotEmpty();
            RuleFor(sistema => sistema.Url).NotEmpty();

            RuleFor(sistema => sistema.Nome).Must((sistema, nome) => NomeDisponivel(sistema)).WithMessage("Este nome já está em uso.");
        }

        private bool NomeDisponivel(Sistema sistema)
        {
            Sistema noBanco = dao.FindByNome(sistema.Nome);

            if (noBanco == null)
                return true;

            if (sistema.Id == 0)
                return podeSalvar(sistema, noBanco);

            return podeAlterar(sistema, noBanco);
        }

        private bool podeAlterar(Sistema sistema, Sistema noBanco)
        {
            if (sistema.Id == noBanco.Id)
                return true;

            return !sistema.Nome.Equals(noBanco.Nome);
        }

        private bool podeSalvar(Sistema sistema, Sistema noBanco)
        {
            return !sistema.Nome.Equals(noBanco.Nome);
        }

    }
}