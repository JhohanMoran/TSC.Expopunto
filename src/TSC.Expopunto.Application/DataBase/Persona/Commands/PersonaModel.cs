using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Persona.Commands
{
    public class PersonaModel
    {
        public int Opcion { get; set; }
        public int Id { get; set; }
        public char CodTipoPersona { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; }

        
    }
}
