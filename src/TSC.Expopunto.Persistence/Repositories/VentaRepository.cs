using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params;
using TSC.Expopunto.Application.Interfaces.Venta;
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

        public async Task<VentaEntity> ActualizarVentaAsync(
            VentaEntity venta
        )
        {
            var parameters = new
            {
                pOpcion = (int)OperationType.Update,

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

                pIdUsuario = venta.IdUsuario,
                pActivo = venta.Activo
            };

            var ventaId = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetVenta",
                parameters
            );

            venta.AsignarId(ventaId); 

            int index = 0;
            foreach (var d in venta.Detalles)
            {
                var detalleId = await _dapperCommandService.ExecuteScalarAsync(
                    "uspSetDetalleVenta",
                    new
                    {
                        pOpcion = d.Id == 0 ? (int)OperationType.Create : (int)OperationType.Update,
                        pId = d.Id,
                        pIdVenta = ventaId,
                        pIdProductoVariante = d.IdProductoVariante,
                        pCantidad = d.Cantidad,
                        pIdDescuento = d.IdDescuento,
                        pPrecioUnitario = d.PrecioUnitario,
                        pActivo = d.Activo
                    });

                venta.AsignarIdDetalle(index, detalleId, ventaId);
                index++;
            }

            return venta;
        }

        public async Task<VentaEntity> CrearVentaAsync(
            VentaEntity venta
        )
        {
            var parameters = new
            {
                pOpcion = (int)OperationType.Create,

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

                pIdUsuario = venta.IdUsuario,
                pActivo = venta.Activo
            };

            var ventaId = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetVenta", 
                parameters
            );

            venta.AsignarId(ventaId);

            int index = 0;
            foreach (var d in venta.Detalles)
            {
                var detalleId = await _dapperCommandService.ExecuteScalarAsync(
                    "uspSetDetalleVenta",
                    new {
                        pOpcion = (int)OperationType.Create,
                        pId = 0,
                        pIdVenta = ventaId,
                        pIdProductoVariante = d.IdProductoVariante,
                        pCantidad = d.Cantidad,
                        pIdDescuento = d.IdDescuento,
                        pPrecioUnitario = d.PrecioUnitario
                    });

                venta.AsignarIdDetalle(index, detalleId, ventaId);
                index++;
            }

            return venta;
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

        public async Task<VentaEntity> ObtenerVentaPorIdAsync(int id)
        {
            var parameters = new
            {
                pOpcion = 2,
                pId = id
            };

            var response = 
                await _dapperQueryService
                    .QueryFirstOrDefaultAsync<VentaEntity>("uspGetVentas", parameters);

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
