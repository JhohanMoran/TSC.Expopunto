using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstado.Queries.ObtenerVentaEstadoPorId
{
    public record ObtenerDocumentoEstadoPorIdQuery(int Id) : IRequest<DocumentoEstadoDTO?>;
}
