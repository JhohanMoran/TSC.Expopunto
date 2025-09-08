using FluentValidation;
using TSC.Expopunto.Application.DataBase.Perfil.Commands;

namespace TSC.Expopunto.Application.Validators.Perfil
{
    public class CrearPerfilValidator : AbstractValidator<PerfilModel>
    {
        public CrearPerfilValidator()
        {
            //RuleFor(x => x.Opcion).GreaterThan(0).LessThanOrEqualTo(3);
            //RuleFor(x => x.IdUsuario).GreaterThan(0);
        }
    }
}
