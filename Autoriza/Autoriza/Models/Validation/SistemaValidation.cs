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
            RuleFor(sistema => sistema.ChaveIdentificacao).Length(5, 30).NotEmpty();

            RuleFor(sistema => sistema.Nome).Must((sistema, nome) => NomeDisponivel(sistema)).WithMessage("Este nome já está em uso.");
            RuleFor(sistema => sistema.ChaveIdentificacao).Must((sistema, chave) => ChaveIdentificacaoDisponivel(sistema)).WithMessage("Este chave de identificação já está em uso.");
        }

        private bool ChaveIdentificacaoDisponivel(Sistema sistema)
        {
            Sistema noBanco = dao.FindByChaveIdentificacao(sistema.ChaveIdentificacao);

            if (noBanco == null)
                return true;

            if (sistema.Id == 0)
                return podeSalvarChaveIdentificacao(sistema, noBanco);

            return podeAlterarChaveIdentificacao(sistema, noBanco);
        }

        private bool podeAlterarChaveIdentificacao(Sistema sistema, Sistema noBanco)
        {
            if (sistema.Id == noBanco.Id)
                return true;

            return !sistema.ChaveIdentificacao.Equals(noBanco.ChaveIdentificacao);
        }

        private bool podeSalvarChaveIdentificacao(Sistema sistema, Sistema noBanco)
        {
            return !sistema.ChaveIdentificacao.Equals(noBanco.ChaveIdentificacao);
        }

        private bool NomeDisponivel(Sistema sistema)
        {
            Sistema noBanco = dao.FindByNome(sistema.Nome);

            if (noBanco == null)
                return true;

            if (sistema.Id == 0)
                return podeSalvarNome(sistema, noBanco);

            return podeAlterarNome(sistema, noBanco);
        }

        private bool podeAlterarNome(Sistema sistema, Sistema noBanco)
        {
            if (sistema.Id == noBanco.Id)
                return true;

            return !sistema.Nome.Equals(noBanco.Nome);
        }

        private bool podeSalvarNome(Sistema sistema, Sistema noBanco)
        {
            return !sistema.Nome.Equals(noBanco.Nome);
        }

    }
}