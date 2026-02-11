using FluentValidation;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Crear;

namespace TSC.Expopunto.Application.Validators.GuiaEntrada
{
    public class CrearGuiaEntradaCommandValidator : AbstractValidator<CrearGuiaEntradaCommand>
    {
        public CrearGuiaEntradaCommandValidator()
        {
            RuleFor(x => x.IdProveedor)
            .GreaterThan(0).WithMessage("El proveedor es obligatorio.");

            RuleFor(x => x.Fecha)
                .NotEmpty().WithMessage("La fecha es obligatoria.");
            RuleFor(x => x.Numero)
                .Length(8, 8).WithMessage("El número de la guía debe tener 8 caracteres");


            RuleForEach(x => x.Detalles).ChildRules(detalle =>
            {

                detalle.RuleFor(d => d.Cantidad)
                    .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
            });
        }

    }
}
