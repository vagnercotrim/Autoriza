using Autoriza.DAO;
using FluentValidation;

namespace Autoriza.Models.Validation
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        
        private readonly UsuarioDAO _dao;

        public UsuarioValidation(UsuarioDAO dao)
        {
            _dao = dao;

            RuleFor(usuario => usuario.Nome).NotEmpty();
            RuleFor(usuario => usuario.Login).NotEmpty();
            RuleFor(usuario => usuario.Senha).NotEmpty();
            RuleFor(usuario => usuario.Email).NotEmpty().EmailAddress();

            RuleFor(usuario => usuario.Login).Must((usuario, nome) => LoginDisponivel(usuario)).WithMessage("Este login já está em uso.");
            RuleFor(usuario => usuario.Email).Must((usuario, email) => EmailDisponivel(usuario)).WithMessage("Este email já está em uso.");
        }

        private bool LoginDisponivel(Usuario usuario)
        {
            Usuario noBanco = _dao.FindByLogin(usuario.Login);

            if (noBanco == null)
                return true;

            return noBanco.Id == usuario.Id;
        }

        private bool EmailDisponivel(Usuario usuario)
        {
            Usuario noBanco = _dao.FindByEmail(usuario.Email);
            
            if (noBanco == null)
                return true;

            return noBanco.Id == usuario.Id;
        }

    }
}