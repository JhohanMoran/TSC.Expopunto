using FluentValidation;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Eliminar;

namespace TSC.Expopunto.Application.Validators.GuiaEntrada
{
    public class EliminarDetalleGuiaEntradaCommandValidator : AbstractValidator<EliminarDetalleGuiaEntradaCommand>
    {
        public EliminarDetalleGuiaEntradaCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("El id es necesario");
        }
    }
}
