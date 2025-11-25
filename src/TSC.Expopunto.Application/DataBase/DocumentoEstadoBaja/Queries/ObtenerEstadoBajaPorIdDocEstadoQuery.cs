using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.Queries
{
    public record ObtenerEstadoBajaPorIdDocEstadoQuery (int IdDocumentoEstado) : IRequest<DocumentoEstadoBajaDTO?>;
}
