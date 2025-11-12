using MediatR;
using TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.DTO;

namespace TSC.Expopunto.Application.DataBase.DocumentoEstadoBaja.Queries
{
    public class ObtenerEstadoBajaPorIdDocEstadoHandler : IRequestHandler<ObtenerEstadoBajaPorIdDocEstadoQuery, DocumentoEstadoBajaDTO?>
    {

        public ObtenerEstadoBajaPorIdDocEstadoHandler()
        {
                
        }
        public Task<DocumentoEstadoBajaDTO?> Handle(ObtenerEstadoBajaPorIdDocEstadoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
