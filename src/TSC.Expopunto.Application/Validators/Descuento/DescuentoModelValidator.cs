using FluentValidation;
using TSC.Expopunto.Application.DataBase.Descuento.Commands;

namespace TSC.Expopunto.Application.Validators.Descuento
{
    public class DescuentoModelValidator : AbstractValidator<DescuentoModel>
    {
        public DescuentoModelValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("El tipo es requerido");
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("El valor debe ser mayor a 0");
        }
    }
}