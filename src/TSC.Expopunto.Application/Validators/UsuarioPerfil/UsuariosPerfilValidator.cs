using FluentValidation;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands;

namespace TSC.Expopunto.Application.Validators.UsuarioPerfil
{
    public class UsuariosPerfilValidator : AbstractValidator<UsuariosPerfilModel>
    {
        public UsuariosPerfilValidator()
        {
            RuleFor(x => x.Opcion)
                .GreaterThan(0)
                .LessThanOrEqualTo(3);
            RuleFor(x => x.IdUsuario)
                .GreaterThan(0);
            RuleFor(x => x.IdPerfil)
                .GreaterThan(0);
            RuleFor(x => x.IdUsuarioProceso)
                .GreaterThan(0);
        }
    }
}
