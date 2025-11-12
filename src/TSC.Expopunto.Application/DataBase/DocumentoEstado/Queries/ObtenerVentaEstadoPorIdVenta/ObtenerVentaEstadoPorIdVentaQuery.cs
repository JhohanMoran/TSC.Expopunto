using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstado.DTO;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstado.Queries.ObtenerVentaEstadoPorIdVenta
{
    public record ObtenerVentaEstadoPorIdVentaQuery(int IdReferencia) : IRequest<DocumentoEstadoDTO?>;
}
