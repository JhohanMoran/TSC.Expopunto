using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasConformeSige
{
    public class ObtenerGuiasConformeSigeHandler : IRequestHandler<ObtenerGuiasConformeSigeQuery, PagedResult<GuiaConformeSigeDto>>
    {
        private readonly IGuiaEntradaRepository _repository;
        public ObtenerGuiasConformeSigeHandler(IGuiaEntradaRepository repository)
        {
            _repository = repository;
        }
        public async Task<PagedResult<GuiaConformeSigeDto>> Handle(ObtenerGuiasConformeSigeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerGuiasConformeSigeAsync(request.parametros);
        }
    }
}
