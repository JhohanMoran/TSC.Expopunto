using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Persona.Queries.Models
{
    public class PersonaTodosModel
    {
        public int Id { get; set; }
        public int CodTipoPersona { get; set; }
        public string TipoPersona { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public bool Activo { get; set; }
        public string Auditoria { get; set; }
        public string TotalRegistros { get; set; }
    }
}
