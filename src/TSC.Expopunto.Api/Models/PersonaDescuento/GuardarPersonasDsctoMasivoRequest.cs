using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;

namespace TSC.Expopunto.Api.Models.PersonaDescuento
{
    public class GuardarPersonasDsctoMasivoRequest
    {
        public GuardarPersonaDescuentoRequest guardarDsctoRequest { get; set; }
        public PersonasListaParametros listarParametros { get; set; }
        public bool seleccionoTodos { get; set; }
        public List<int> idsPersonasSeleccionadas { get; set; }

    }
}
