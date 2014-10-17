using FluentValidation;

namespace Autoriza.Models.Validation
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {

        public UsuarioValidation()
        {
            RuleFor(usuario => usuario.Login).NotEmpty();
            RuleFor(usuario => usuario.Senha).NotEmpty();
            RuleFor(usuario => usuario.Email).NotEmpty().EmailAddress();
        }

    }
}