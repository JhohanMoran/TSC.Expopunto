using FluentValidation;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Eliminar;

namespace TSC.Expopunto.Application.Validators.GuiaEntrada
{
    public class EliminarGuiaEntradaCommandValidator : AbstractValidator<EliminarGuiaEntradaCommand>
    {
        public EliminarGuiaEntradaCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("El id es necesario");
        }
    }
}
