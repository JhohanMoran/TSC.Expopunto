using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerDetallesGuiaEntradaPorIdGuia
{
    public record ObtenerDetallesGuiaEntradaPorIdGuiaQuery(int IdGuia) : IRequest<List<DetalleGuiaEntradaDTO>> { }
}
