using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasConformeSigeDetalle
{
    public class ObtenerGuiasConformeSigeDetalleHandler : IRequestHandler<ObtenerGuiasConformeSigeDetalleQuery, PagedResult<GuiaConformeSigeDetalleDto>>
    {
        private readonly IGuiaEntradaRepository _repository;
        public ObtenerGuiasConformeSigeDetalleHandler(IGuiaEntradaRepository repository)
        {
            _repository = repository;
        }
        public async Task<PagedResult<GuiaConformeSigeDetalleDto>> Handle(ObtenerGuiasConformeSigeDetalleQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerGuiasConformeSigeDetalleAsync(request.parametros);
        }
    }
}
