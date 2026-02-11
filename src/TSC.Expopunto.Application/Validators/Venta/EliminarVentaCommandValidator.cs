using FluentValidation;
using TSC.Expopunto.Application.DataBase.Venta.Commands.EliminarVenta;

namespace TSC.Expopunto.Application.Validators.Venta
{
    public class EliminarVentaCommandValidator : AbstractValidator<EliminarVentaCommand>
    {
        public EliminarVentaCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("El ID es obligatorio para poder eliminar");
            RuleFor(x => x.IdUsuario).GreaterThan(0).WithMessage("El IdUsuario es obligatorio");
        }
    }
}
