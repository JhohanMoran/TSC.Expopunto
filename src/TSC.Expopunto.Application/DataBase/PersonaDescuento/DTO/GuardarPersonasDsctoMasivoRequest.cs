using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.PersonaDescuento.DTO
{
    public class GuardarPersonasDsctoMasivoRequest
    {
        public GuardarDsctoRequest guardarDsctoRequest { get; set; }
        public bool seleccionoTodos { get; set; }
        public List<int> idsPersonasSeleccionadas { get; set; }
        public PersonasListaParametros listarParametros { get; set; }
    }

    public class GuardarDsctoRequest
    {
        public int? Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? ValorDescuento { get; set; }
        public int? IdUsuario { get; set; }
    }
}
