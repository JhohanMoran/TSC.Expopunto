using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerDetallesGuiaEntradaPorIdGuia
{
    public record ObtenerDetallesGuiaEntradaPorIdGuiaQuery(int IdGuia) : IRequest<List<DetalleGuiaEntradaDTO>> { }
}
