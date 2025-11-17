using MediatR;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.DataBase.Parametro.Queries;
using TSC.Expopunto.Application.DataBase.Persona.Queries;
using TSC.Expopunto.Application.DataBase.Sede.Queries;
using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;
using TSC.Expopunto.Application.DTOs.Documentos;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;
using TSC.Expopunto.Application.Interfaces.Services;

namespace TSC.Expopunto.Application.Features.Documentos.Queries
{
    public class GenerarDocumentoPdfHandler : IRequestHandler<GenerarDocumentoPdfQuery, DocumentoPdfResponse?>
    {
        private readonly IDocumentoPdfService _documentoService;
        private readonly IVentaRepository _repository;
        private readonly IParametroQuery _parametroQuery;
        private readonly ISedeQuery _sedeQuery;
        private readonly ITipoDocumentoQuery _tipoDocumentoQuery;
        private readonly IPersonaQuery _personaQuery;
        private readonly ITipoMonedaQuery _tipoMonedaQuery;
        private readonly ITipoComprobanteQuery _tipoComprobanteQuery;

        public GenerarDocumentoPdfHandler(
            IDocumentoPdfService documentoService,
            IVentaRepository repository,
            IParametroQuery parametroQuery,
            ISedeQuery sedeQuery,
            ITipoDocumentoQuery tipoDocumentoQuery,
            IPersonaQuery personaQuery,
            ITipoMonedaQuery tipoMonedaQuery,
            ITipoComprobanteQuery tipoComprobanteQuery
        )
        {
            _documentoService = documentoService;
            _repository = repository;
            _parametroQuery = parametroQuery;
            _sedeQuery = sedeQuery;
            _tipoDocumentoQuery = tipoDocumentoQuery;
            _personaQuery = personaQuery;
            _tipoMonedaQuery = tipoMonedaQuery;
            _tipoComprobanteQuery = tipoComprobanteQuery;
        }

        public async Task<DocumentoPdfResponse?> Handle(GenerarDocumentoPdfQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Datos de Empresa
                var empresa = await _parametroQuery.ObtenerDatosEmpresa();

                // 2. Datos de Venta
                var venta = await _repository.ObtenerVentaPorIdAsync(request.ventaId);

                if (venta == null)
                {
                    throw new Exception($"No se encontró la venta con el ID {request.ventaId}. Verifique que el identificador sea correcto.");
                }

                // 3. Retornar el detalle completo de la venta actualizada
                var ventaDetalleRespuesta = await _repository.ObtenerDetalleVentaPorIdVentaAsync(venta.Id);

                // 4. Retornar las formas de pago de la venta
                var ventaFormasPagoRespuesta = await _repository.ObtenerVentasFormaPagoPorIdVentaAsync(venta.Id);

                // 5. Retorna Datos de Sede
                var sede = await _sedeQuery.ObtenerSedePorIdAsync(venta.IdSede ?? 0);

                // 6. Obtener Datos de Persona
                var persona = await _personaQuery.ListarPersonasPorIdAsync(venta.IdPersona ?? 0);

                // 7. Obtener datos de Tipo de Documento
                var tipoDocumento = await _tipoDocumentoQuery.ObtenerTipoDocumentoPorIdAsync(persona!.IdTipoDocumento);

                // 8. Obtener datos de Tipo de Moneda
                var tipoMoneda = await _tipoMonedaQuery.ObtenerTipoMonedaPorIdAsync(venta.IdTipoMoneda ?? 0);

                // 9. Obtener El tiop de comprobante
                var tipoComprobante = await _tipoComprobanteQuery.ObtenerTipoComprobantePorIdAsync(venta.IdTipoComprobante ?? 0);

                venta.Detalles = ventaDetalleRespuesta.Select(x => new DetalleVentaDTO
                {
                    Id = x.Id,             // Id asignado en la BD
                    IdVenta = x.IdVenta,   // también ya viene actualizado
                    IdProductoVariante = x.IdProductoVariante,
                    Descripcion = x.Descripcion,
                    Cantidad = x.Cantidad,
                    PrecioUnitario = x.PrecioUnitario,
                    IdDescuento = x.IdDescuento,
                    ValorDescuento = x.ValorDescuento,
                    SubTotal = x.SubTotal,
                    Activo = x.Activo
                }).ToList();

                venta.FormasPago = ventaFormasPagoRespuesta.Select(x => new VentasFormaPagoDTO
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

                /// "20123456789|03|B002-2352|2025-11-12|4.00|44.50|1|89187294"
                string qrData = string.Concat(
                    empresa.Ruc, "|",
                    tipoComprobante.Codigo, "|",
                    venta.Serie, "-", venta.Numero, "|",
                    Convert.ToDateTime(venta.Fecha).ToString("yyyy-MM-dd"), "|",
                    (venta.IGV ?? 0).ToString("0.00"), "|",
                    (venta.ImporteTotal ?? 0).ToString("0.00"), "|",
                    Convert.ToInt32(tipoDocumento.Codigo).ToString(), "|",
                    venta.DocumentoPersona
                );

                // Generar PDF
                return new DocumentoPdfResponse()
                {
                    ArchivoPdf = _documentoService.GenerarPdf(new ImpresionVentaDTO()
                    {
                        Empresa = empresa,
                        Sede = sede,
                        Venta = venta,
                        TipoMoneda = tipoMoneda,
                        qrData = qrData
                    }),
                    NombreArchivo = venta.Serie + "-" + venta.Numero
                };

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
