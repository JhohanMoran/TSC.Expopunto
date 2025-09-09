using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Commands;

namespace TSC.Expopunto.Application.Validators.PerfilMenu
{
    public class PerfilMenuValidator : AbstractValidator<PerfilMenuModel>
    {
        public PerfilMenuValidator()
        {
            RuleFor(x => x.Opcion)
                .GreaterThan(0)
                .LessThanOrEqualTo(3);
            RuleFor(x => x.IdPerfil)
                .GreaterThan(0);
            RuleFor(x => x.IdMenu)
                .GreaterThan(0);
            RuleFor(x => x.IdUsuarioProceso)
                .GreaterThan(0);
        }
    }
}
