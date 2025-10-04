using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.Interfaces.GuiaEntrada;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;



namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Crear
{
    public class CrearGuiaEntradaHandle : IRequestHandler<CrearGuiaEntradaCommand, GuiaEntradaDTO>
    {
        private readonly IGuiaEntradaRepository _repository;

        public CrearGuiaEntradaHandle(IGuiaEntradaRepository repository)
        {
            _repository = repository;
        }

        public async Task<GuiaEntradaDTO> Handle(CrearGuiaEntradaCommand request, CancellationToken cancellationToken)
        {
            GuiaEntradaEntity guiaEntrada = new GuiaEntradaEntity();

            // 1️. Construir la entidad
            guiaEntrada = new GuiaEntradaEntity(
                request.Id,
                request.Serie,
                request.Numero,
                request.Fecha,
                request.Hora,
                request.IdProveedor,
                request.TipoGuia,
                request.Observacion,
                request.TotalCantidad,
                request.TotalCosto
            );

            foreach (var d in request.Detalles)
            {
                guiaEntrada.AgregarDetalle(
                    d.Id,
                    d.IdGuiaEntrada,
                    d.IdProducto,
                    d.IdUnidadMedida,
                    d.Cantidad,
                    d.CostoUnitario
                );
            }

            // 2. Guardar en BD (Dapper/SP)
            GuiaEntradaEntity guiaEntradaRespuesta = await _repository.CrearGuiaEntradaAsync(guiaEntrada);

            // Retornar un DTO
            return new GuiaEntradaDTO
            {
                Id = guiaEntradaRespuesta.Id, // ahora ya tiene el Id asignado desde la BD
                Serie = guiaEntradaRespuesta.Serie,
                Numero = guiaEntradaRespuesta.Numero,
                Fecha = guiaEntradaRespuesta.Fecha,
                Hora = guiaEntrada.Hora,
                IdProveedor = guiaEntradaRespuesta.IdProveedor,
                TipoGuia = guiaEntradaRespuesta.TipoGuia,
                Observacion = guiaEntradaRespuesta.Observacion,
                TotalCantidad = guiaEntradaRespuesta.TotalCantidad,
                TotalCosto = guiaEntradaRespuesta.TotalCosto,
                Detalles = guiaEntradaRespuesta.Detalles.Select(x => new DetalleGuiaEntradaDTO
                {
                    Id = x.Id,             // Id asignado en la BD
                    IdGuiaEntrada = x.IdGuiaEntrada,   // también ya viene actualizado
                    IdProducto = x.IdProducto,
                    IdUnidadMedida = x.IdUnidadMedida,
                    Cantidad = x.Cantidad,
                    CostoUnitario = x.CostoUnitario,
                }).ToList()
            };
        }

    }
}
