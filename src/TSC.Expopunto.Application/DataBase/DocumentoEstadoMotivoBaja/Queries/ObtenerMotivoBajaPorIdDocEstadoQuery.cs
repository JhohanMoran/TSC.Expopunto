using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoMotivoBaja.DTO;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoMotivoBaja.Queries
{
    public record ObtenerMotivoBajaPorIdDocEstadoQuery (int IdDocumentoEstado) : IRequest<DocumentoEstadoBajaMotivoDTO?>;
}
