using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.Commands
{
    public record GuardarPersonaDsctoMasivoCommand(
    int Id,
    DateTime FechaInicio,
    DateTime FechaFin,
    decimal ValorDescuento,
    int IdUsuario,
    bool SeleccionoTodos,
    List<int> IdsSeleccionados, // Cambiado de IdsPersonasSeleccionadas
    List<int> IdsExcluidos,     // Nueva lista para exclusiones reales
    PersonasListaParametros ListarParametros
) : IRequest<bool>;
}
