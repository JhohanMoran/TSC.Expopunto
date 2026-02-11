using MediatR;
using TSC.Expopunto.Application.DataBase.VentaTipoOperacion.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.VentaTipoOperacion;

namespace TSC.Expopunto.Application.DataBase.VentaTipoOperacion.Queries
{
    public class ObtenerVentaTiposOperacionHandler : IRequestHandler<ObtenerVentaTiposOperacionQuery, List<VentaTipoOperacionDTO>>
    {
        private readonly IVentaTipoOperacionRepository _repository;
        public ObtenerVentaTiposOperacionHandler(IVentaTipoOperacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VentaTipoOperacionDTO>> Handle(ObtenerVentaTiposOperacionQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.ListarVentaTiposOperacion();
            return resultado;
        }
    }
}
