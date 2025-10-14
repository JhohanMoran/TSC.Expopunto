using DocumentFormat.OpenXml.Office.Y2022.FeaturePropertyBag;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
