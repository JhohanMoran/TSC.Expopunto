using MediatR;
using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Usuario.Queries
{
    public record LoginUsuarioQuery(int idPerfil, string Usuario, string Contrasena) : IRequest<RespuestaLoginModel>;

}
