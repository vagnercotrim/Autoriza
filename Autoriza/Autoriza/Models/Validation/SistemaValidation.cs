using Autoriza.DAO;
using FluentValidation;

namespace Autoriza.Models.Validation
{
    public class SistemaValidation : AbstractValidator<Sistema>
    {

        private readonly SistemaDAO _dao;

        public SistemaValidation(SistemaDAO dao)
        {
            _dao = dao;

            RuleFor(sistema => sistema.Nome).NotEmpty();
            RuleFor(sistema => sistema.Url).NotEmpty();
            RuleFor(sistema => sistema.ChaveIdentificacao).Length(5, 30).NotEmpty();

            RuleFor(sistema => sistema.Nome).Must((sistema, nome) => NomeDisponivel(sistema)).WithMessage("Este nome já está em uso.");
            RuleFor(sistema => sistema.ChaveIdentificacao).Must((sistema, chave) => ChaveIdentificacaoDisponivel(sistema)).WithMessage("Este chave de identificação já está em uso.");
        }

        private bool ChaveIdentificacaoDisponivel(Sistema sistema)
        {
            Sistema noBanco = _dao.FindByChaveIdentificacao(sistema.ChaveIdentificacao);

            if (noBanco == null)
                return true;

            return noBanco.Id == sistema.Id;
        }

        private bool NomeDisponivel(Sistema sistema)
        {
            Sistema noBanco = _dao.FindByNome(sistema.Nome);

            if (noBanco == null)
                return true;

            return noBanco.Id == sistema.Id;
        }

    }
}