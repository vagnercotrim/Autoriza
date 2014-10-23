using Autoriza.DAO;
using FluentValidation;

namespace Autoriza.Models.Validation
{
    public class PerfilValidation : AbstractValidator<Perfil>
    {

        private readonly PerfilDAO _dao;

        public PerfilValidation(PerfilDAO dao)
        {
            _dao = dao;

            RuleFor(perfil => perfil.Nome).NotEmpty();
            RuleFor(perfil => perfil.Descricao).NotEmpty();

            RuleFor(perfil => perfil.Nome).Must((perfil, nome) => NomeDisponivel(perfil)).WithMessage("Este nome já está em uso.");
        }

        private bool NomeDisponivel(Perfil perfil)
        {
            Perfil noBanco = _dao.FindByNome(perfil.Sistema.Id, perfil.Nome);

            if (noBanco == null)
                return true;

            return noBanco.Id == perfil.Id;
        }

    }
}