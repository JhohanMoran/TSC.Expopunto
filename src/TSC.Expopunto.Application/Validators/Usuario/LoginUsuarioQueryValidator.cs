using FluentValidation;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;

namespace TSC.Expopunto.Application.Validators.Usuario
{
    public class LoginUsuarioQueryValidator : AbstractValidator<LoginUsuarioQuery>
    {
        public LoginUsuarioQueryValidator()
        {
            RuleFor(x => x.idPerfil).GreaterThan(0).WithMessage("El perfil es obligatorio.");
            RuleFor(x => x.Usuario).NotEmpty().WithMessage("El usuario es obligatorio.");
            RuleFor(x => x.Contrasena).NotEmpty().WithMessage("La contraseña es obligatoria.");
        }
    }
}
