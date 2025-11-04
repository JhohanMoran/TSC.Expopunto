using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Numerics;
using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        public readonly IDapperCommandService _dapperCommandService;
        public readonly IDapperQueryService _dapperQueryService;
        public VentaRepository(
            IDapperCommandService dapperCommandService,
            IDapperQueryService dapperQueryService
        )
        {
            _dapperCommandService = dapperCommandService;
            _dapperQueryService = dapperQueryService;
        }

        public async Task<VentaEntity> GuardarVentaAsync(
            VentaEntity venta
        )
        {
            int index = 0;

            try
            {
                var parameters = new
                {
                    pOpcion = venta.Id > 0 ? (int)OperationType.Update : (int)OperationType.Create,
                    pId = venta.Id,
                    pFecha = venta.Fecha,
                    pHora = venta.Hora,
                    pIdSede = venta.IdSede,
                    pIdTipoComprobante = venta.IdTipoComprobante,
                    pSerie = venta.Serie,
                    pNumero = venta.Numero,
                    pIdPersona = venta.IdPersona,
                    pIdTipoMoneda = venta.IdTipoMoneda,
                    pIdUsuarioVendedor = venta.IdUsuarioVendedor,
                    pDescuentoTotal = venta.DescuentoTotal,
                    pSubTotal = venta.SubTotal,
                    pImpuesto = venta.Impuesto,
                    pTotal = venta.Total,
                    pIdUsuario = venta.IdUsuario,
                    pActivo = venta.Activo
                };

                var ventaId = await _dapperCommandService.ExecuteScalarAsync(
                    "uspSetVenta",
                    parameters
                );

                venta.AsignarId(ventaId);

                index = 0;
                foreach (var d in venta.Detalles)
                {
                    var detalleId = await _dapperCommandService.ExecuteScalarAsync(
                        "uspSetDetalleVenta",
                        new
                        {
                            pOpcion = d.Id > 0 ? (int)OperationType.Update : (int)OperationType.Create,
                            pId = d.Id,
                            pIdVenta = ventaId,
                            pIdProductoVariante = d.IdProductoVariante,
                            pIdTipoOperacion = d.IdTipoOperacion,
                            pCodigoTipoOperacion = d.CodigoTipoOperacion,
                            pDescripcion = d.Descripcion,
                            pCantidad = d.Cantidad,
                            pPrecioUnitario = d.PrecioUnitario,
                            pAplicaICBP = d.AplicaICBP,
                            pIdDescuento = d.IdDescuento,
                            pValorDescuento = d.ValorDescuento,
                            pSubtotal = d.SubTotal,
                            pActivo = d.Activo
                        });

                    venta.AsignarIdDetalle(index, detalleId, ventaId);
                    index++;
                }

                index = 0;
                foreach (var d in venta.FormasPago)
                {
                    var ventaFormaPagoId = await _dapperCommandService.ExecuteScalarAsync(
                        "uspSetVentaFormaPago",
                        new
                        {
                            pOpcion = d.Id > 0 ? (int)OperationType.Update : (int)OperationType.Create,
                            pId = d.Id,
                            pIdVenta = ventaId,
                            pIdFormaPago = d.IdFormaPago,
                            pMonto = d.Monto,
                            pReferenciaPago = d.ReferenciaPago
                        });

                    venta.AsignarIdVentaFormaPago(index, ventaFormaPagoId, ventaId);
                    index++;
                }

                return venta;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<int> EliminarVentaAsync(int id, int idUsuario)
        {
            var parameters = new
            {
                pOpcion = (int)OperationType.Delete,
                pId = id,
                pIdUsuario = idUsuario
            };
            var ventaId = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetVenta",
                parameters
            );
            return ventaId;
        }

        public async Task<List<DetalleVentaDTO>> ObtenerDetalleVentaPorIdVentaAsync(int idVenta)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdVenta = idVenta,
            };

            var response =
                await _dapperQueryService
                    .QueryAsync<DetalleVentaDTO>("uspGetDetalleVenta", parameters);

            return response.ToList();
        }

        public async Task<VentaDTO> ObtenerVentaPorIdAsync(int id)
        {
            var parameters = new
            {
                pOpcion = 2,
                pId = id
            };

            var response =
                await _dapperQueryService
                    .QueryFirstOrDefaultAsync<VentaDTO>("uspGetVentas", parameters);

            return response;
        }

        public async Task<PagedResult<VentaDTO>> ObtenerVentasAsync(
            ObtenerVentasParams parametros
        )
        {
            var parameters = new
            {
                pOpcion = 1,

                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pOrdenPor = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,

                pSerie = parametros.Serie,
                pNumero = parametros.Numero
            };

            var response = await _dapperQueryService
                                .QueryAsync<VentaDTO>("uspGetVentas", parameters);

            var ventasLista = response.ToList();
            var totalRegistros = ventasLista.FirstOrDefault()?.TotalRegistros ?? 0;

            return new PagedResult<VentaDTO>
            {
                Data = ventasLista,
                Total = totalRegistros,
                Pagina = parametros.Pagina,
                FilasPorPagina = parametros.FilasPorPagina
            };
        }

        public async Task<List<VentasFormaPagoDTO>> ObtenerVentasFormaPagoPorIdVentaAsync(int idVenta)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdVenta = idVenta,
            };

            var response =
                await _dapperQueryService
                    .QueryAsync<VentasFormaPagoDTO>("uspGetVentasFormaPago", parameters);

            return response.ToList();
        }

        public async Task<List<VentaMontoDTO>> ObtenerVentasPorIdPersonaAsync(int idPersona)
        {
            var parameters = new
            {
                pOpcion = 3,
                pIdPersona = idPersona,
            };

            var response =
                await _dapperQueryService
                    .QueryAsync<VentaMontoDTO>("uspGetVentas", parameters);

            return response.ToList();
        }
    }
}
