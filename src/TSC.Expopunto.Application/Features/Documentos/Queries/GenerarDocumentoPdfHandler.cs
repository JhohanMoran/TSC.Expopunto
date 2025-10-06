using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;
using TSC.Expopunto.Application.Interfaces.Services;

namespace TSC.Expopunto.Application.Features.Documentos.Queries
{
    public class GenerarDocumentoPdfHandler : IRequestHandler<GenerarDocumentoPdfQuery, byte[]?>
    {
        private readonly IDocumentoPdfService _documentoService;
        private readonly IVentaRepository _repository;
        public GenerarDocumentoPdfHandler(IDocumentoPdfService documentoService, IVentaRepository repository)
        {
            _documentoService = documentoService;
            _repository = repository;
        }

        public async Task<byte[]?> Handle(GenerarDocumentoPdfQuery request, CancellationToken cancellationToken)
        {

            try
            {

                // 1. Buscar Venta por Id
                var vanta = await _repository.ObtenerVentaPorIdAsync(request.ventaId);

                // 2. Retornar el detalle completo de la venta actualizada
                var ventaDetalleRespuesta = await _repository.ObtenerDetalleVentaPorIdVentaAsync(vanta.Id);

                // 3. Retornar las formas de pago de la venta
                var ventaFormasPagoRespuesta = await _repository.ObtenerVentasFormaPagoPorIdVentaAsync(vanta.Id);


                vanta.Detalles = ventaDetalleRespuesta.Select(x => new DetalleVentaDTO
                {
                    Id = x.Id,             // Id asignado en la BD
                    IdVenta = x.IdVenta,   // también ya viene actualizado
                    IdProductoVariante = x.IdProductoVariante,
                    DescripcionProducto = x.DescripcionProducto,
                    Cantidad = x.Cantidad,
                    PrecioUnitario = x.PrecioUnitario,
                    IdDescuento = x.IdDescuento,
                    ValorDescuento = x.ValorDescuento,
                    SubTotal = x.SubTotal,
                    TipoDescuento = x.TipoDescuento,
                    Activo = x.Activo
                }).ToList();

                vanta.FormasPago = ventaFormasPagoRespuesta.Select(x => new VentasFormaPagoDTO
                {
                    Id = x.Id,
                    IdVenta = x.IdVenta,
                    VentaDescripcionFormaPago = x.VentaDescripcionFormaPago,
                    Monto = x.Monto,
                    ReferenciaPago = x.ReferenciaPago,
                    IdFormaPago = x.IdFormaPago,
                    FormaPago = x.FormaPago,
                    RutaIcono = x.RutaIcono,
                    Activo = x.Activo
                }).ToList();

                // Generar PDF
                return _documentoService.GenerarPdf(vanta);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
