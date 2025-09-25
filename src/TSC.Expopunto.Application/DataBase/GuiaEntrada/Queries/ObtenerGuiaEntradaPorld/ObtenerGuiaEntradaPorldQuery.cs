using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiaEntradaPorld
{
    public record ObtenerGuiaEntradaPorldQuery
    {
        public record ObtenerGuiaEntradaPorIdQuery(int Id) : IRequest<GuiaEntradaEntity?>;
    }
}
