using MediatR;
using TSC.Expopunto.Application.DataBase.EmisionComprobanteSunat.Queries.ObtenerComprobanteSunat.Params;

namespace TSC.Expopunto.Application.DataBase.EmisionComprobanteSunat.Queries.ObtenerComprobanteSunat
{
    public record ObtenerComprobanteSunatQuery(ObtenerComprobanteSunatParams Parametros) : IRequest<Unit>;
}
