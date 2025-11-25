using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.Commands
{
    public record GuardarDocumentoEstadoBajaCommand
    (
        int IdDocumentoEstado,
        int IdUsuario

    ) : IRequest<DocumentoEstadoBajaDTO?>;
}
 