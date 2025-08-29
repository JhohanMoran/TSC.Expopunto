using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands;

namespace TSC.Expopunto.Application.DataBase.UsuariosPerfil.Validators
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
