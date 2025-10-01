using FluentValidation;
using TSC.Expopunto.Application.DataBase.Venta.Commands.Actualizar;

namespace TSC.Expopunto.Application.Validators.Venta
{
    public class ActualizarVentaCommandValidator : AbstractValidator<ActualizarVentaCommand>
    {
        public ActualizarVentaCommandValidator()
        {
            RuleFor(x => x.IdPersona)
            .GreaterThan(0).WithMessage("El cliente es obligatorio.");

            RuleFor(x => x.Fecha)
                .NotEmpty().WithMessage("La fecha es obligatoria.");

            RuleForEach(x => x.Detalles).ChildRules(detalle =>
            {
                detalle.RuleFor(d => d.IdProductoVariante)
                    .GreaterThan(0).WithMessage("Debe especificar un producto válido.");

                detalle.RuleFor(d => d.Cantidad)
                    .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
            });
        }
    }
}
