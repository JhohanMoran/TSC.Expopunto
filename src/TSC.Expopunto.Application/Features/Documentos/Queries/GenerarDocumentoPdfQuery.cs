using MediatR;
using TSC.Expopunto.Application.DTOs.Documentos;

namespace TSC.Expopunto.Application.Features.Documentos.Queries
{
    public record GenerarDocumentoPdfQuery(int ventaId) : IRequest<DocumentoPdfResponse?>;
}
