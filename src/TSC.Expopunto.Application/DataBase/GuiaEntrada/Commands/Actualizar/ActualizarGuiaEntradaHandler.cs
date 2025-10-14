using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Actualizar;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands
{
    public class ActualizarGuiaEntradaHandler : IRequestHandler<ActualizarGuiaEntradaCommand, GuiaEntradaDTO>
    {
        private readonly IGuiaEntradaRepository _repository;

        public ActualizarGuiaEntradaHandler(IGuiaEntradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<GuiaEntradaDTO> Handle(ActualizarGuiaEntradaCommand request, CancellationToken cancellationToken)
        {
            GuiaEntradaEntity venta = new GuiaEntradaEntity();

            // 1️. Recuperar GuiaEntrada existente
            var guiaEntradaExistente = await _repository.ObtenerGuiaEntradaPorIdAsync(request.Id);

            if (guiaEntradaExistente is null)
                throw new KeyNotFoundException($"No se encontró la guiaEntrada con ID {request.Id}");

            // 2️. Actualizar
            var nuevosDetalles = request.Detalles
                .Select(d => new DetalleGuiaEntradaEntity(
                    d.Id,
                    d.IdGuiaEntrada,
                    d.IdProducto,
                    d.IdUnidadMedida,
                    d.Cantidad,
                    d.CostoUnitario,
                    d.Caja,
                    d.CodigoEstilo,
                    d.CodigoPedido,
                    null
                ))
                .ToList();

            guiaEntradaExistente.Actualizar(
                request.Id,
                request.Serie,
                request.Numero,
                request.Fecha,
                request.Hora,
                request.IdProveedor,
                request.TipoGuia,
                request.Observacion,
                request.TotalCantidad,
                request.TotalCosto,
                request.IdUsuario,
                nuevosDetalles
            );

            // 3️. Guardar en BD
            GuiaEntradaEntity guiaEntradaRespuesta = await _repository.ActualizarGuiaEntradaAsync(guiaEntradaExistente);

            // 4. Retornar el detalle completo de la GuiaEntrada actualizada
            var guiaEntradaDetalleRespuesta = await _repository.ObtenerDetalleGuiaEntradaPorIdGuiaAsync(guiaEntradaRespuesta.Id);


            return new GuiaEntradaDTO
            {
                Id = guiaEntradaRespuesta.Id, // ahora ya tiene el Id asignado desde la BD
                Serie = guiaEntradaRespuesta.Serie,
                Numero = guiaEntradaRespuesta.Numero,
                Fecha = guiaEntradaRespuesta.Fecha,
                IdProveedor = guiaEntradaRespuesta.IdProveedor,
                TipoGuia = guiaEntradaRespuesta.TipoGuia,
                Observacion = guiaEntradaRespuesta.Observacion,


                Detalles = guiaEntradaDetalleRespuesta.Select(x => new DetalleGuiaEntradaDTO
                {
                    Id = x.Id, // Id asignado en la BD
                    IdGuiaEntrada = x.IdGuiaEntrada,
                    IdProducto = x.IdProducto,
                    IdUnidadMedida = x.IdUnidadMedida,
                    CodUniMed = x.CodUniMed,
                    Cantidad = x.Cantidad,
                    CostoUnitario = x.CostoUnitario,
                    Caja = x.Caja,
                    CodigoEstilo = x.CodigoEstilo,
                    CodigoPedido = x.CodigoPedido


                }).ToList()
            };
        }

    }
}
