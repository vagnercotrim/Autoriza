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

            if (perfil.Id == 0)
                return podeSalvar(perfil, noBanco);

            return podeAlterar(perfil, noBanco);
        }

        private bool podeAlterar(Perfil perfil, Perfil noBanco)
        {
            if (perfil.Id == noBanco.Id)
                return true;

            return !perfil.Nome.Equals(noBanco.Nome);
        }

        private bool podeSalvar(Perfil perfil, Perfil noBanco)
        {
            return !perfil.Nome.Equals(noBanco.Nome);
        }

    }
}