using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries.Models
{
    public class UsuariosPerfilTodoModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int IdPerfil { get; set; }
        public string PerfilDescripcion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaCreacion { get; set; }
        public int? IdUsuarioActualizacion { get; set; }
        public string? UsuarioActualizacion { get; set; }
        public string? FechaActualizacion { get; set; }
    }
}
