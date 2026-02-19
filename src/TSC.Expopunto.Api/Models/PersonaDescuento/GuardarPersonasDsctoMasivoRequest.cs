using Microsoft.AspNetCore.Mvc;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;



namespace TSC.Expopunto.Api.Models.PersonaDescuento
{
    public class GuardarPersonasDsctoMasivoRequest
    {
        // 1. Datos del descuento (Usa la clase interna de abajo)
        public GuardarDsctoRequest guardarDsctoRequest { get; set; }

        // 2. Filtros de búsqueda para que el SP sepa qué registros afectar globalmente
        public PersonasListaParametros listarParametros { get; set; }

        // 3. Flag principal: ¿Es para los 1,304 registros (true) o solo para algunos (false)?
        public bool seleccionoTodos { get; set; }

        // 4. Lista de IDs específicos (Se usa cuando seleccionoTodos es FALSE)
        public List<int> idsSeleccionados { get; set; }

        // 5. Lista de IDs a ignorar (Se usa cuando seleccionoTodos es TRUE)
        public List<int> idsExcluidos { get; set; }
    }

    // Clase auxiliar para los datos del formulario del diálogo
    public class GuardarDsctoRequest
    {
        public int? Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? ValorDescuento { get; set; }
        public int? IdUsuario { get; set; }
    }
}
