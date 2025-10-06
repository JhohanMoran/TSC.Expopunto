using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Eliminar
{
    public record EliminarGuiaEntradaCommand(int Id) : IRequest<int> { }
}
