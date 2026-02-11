using MediatR;
using TSC.Expopunto.Application.DataBase.MotivoBaja.DTO;

namespace TSC.Expopunto.Application.DataBase.MotivoBaja.Queries.ListarMotivosBaja
{
    public record ListarMotivosBajaQuery () : IRequest<List<MotivoBajaDTO>?>;
}
