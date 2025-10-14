using FluentValidation;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Actualizar;


namespace TSC.Expopunto.Application.Validators.GuiaEntrada
{
    public class ActualizarGuiaEntradaCommandValidator : AbstractValidator<ActualizarGuiaEntradaCommand>
    {
        public ActualizarGuiaEntradaCommandValidator()
        {
            RuleFor(x => x.IdProveedor)
            .GreaterThan(0).WithMessage("El proveedor es obligatorio.");

            RuleFor(x => x.Fecha)
                .NotEmpty().WithMessage("La fecha es obligatoria.");

            RuleForEach(x => x.Detalles).ChildRules(detalle =>
            {
                detalle.RuleFor(d => d.IdProducto)
                    .GreaterThan(0).WithMessage("Debe especificar un producto válido.");

                detalle.RuleFor(d => d.Cantidad)
                    .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
            });
        }
    }
}
