using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Application.Interfaces.GuiaEntrada;
using TSC.Expopunto.Common;




namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada
{
    public class ObtenerGuiasEntradaHandler : IRequestHandler<ObtenerGuiasEntradaQuery, PagedResult<GuiaEntradaDTO>>
    {
        private readonly IGuiaEntradaRepository _repository;

        public ObtenerGuiasEntradaHandler(IGuiaEntradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<GuiaEntradaDTO>> Handle(ObtenerGuiasEntradaQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerGuiasEntradaAsync(request.Parametros);
        }
    } 
      
}
