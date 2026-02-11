using MediatR;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiaEntradaPorld
{
    public record ObtenerGuiaEntradaPorldQuery
    {
        public record ObtenerGuiaEntradaPorIdQuery(int Id) : IRequest<GuiaEntradaEntity?>;
    }
}
