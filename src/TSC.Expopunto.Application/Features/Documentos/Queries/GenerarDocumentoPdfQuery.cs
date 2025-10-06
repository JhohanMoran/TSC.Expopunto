using MediatR;

namespace TSC.Expopunto.Application.Features.Documentos.Queries
{
    public record GenerarDocumentoPdfQuery(int ventaId) : IRequest<byte[]?>;
}
