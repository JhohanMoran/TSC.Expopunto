using DocumentFormat.OpenXml.Spreadsheet;
using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasPendientesAprobar.Params;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Persistence.Repositories
{
    public class GuiaEntradaRepository : IGuiaEntradaRepository
    {
        public readonly IDapperCommandService _dapperCommandService;
        public readonly IDapperQueryService _dapperQueryService;
        public GuiaEntradaRepository(
            IDapperCommandService dapperCommandService,
            IDapperQueryService dapperQueryService
        )
        {
            _dapperCommandService = dapperCommandService;
            _dapperQueryService = dapperQueryService;
        }

        public async Task<GuiaEntradaEntity> ActualizarGuiaEntradaAsync(
            GuiaEntradaEntity guiaEntrada
        )
        {
            var parameters = new
            {
                pOpcion = (int)OperationType.Update,

                pId = guiaEntrada.Id,
                pSerie = guiaEntrada.Serie,
                pNumero = guiaEntrada.Numero,
                pFecha = guiaEntrada.Fecha,
                pHora = guiaEntrada.Hora,
                pTipoGuia = guiaEntrada.TipoGuia,
                pIdProveedor = guiaEntrada.IdProveedor,
                pObservacion = guiaEntrada.Observacion,
                pTotalCantidad = guiaEntrada.TotalCantidad,
                pIdUsuario = guiaEntrada.IdUsuario,
            };

            var guiaEntradaId = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetGuiaEntrada",
                parameters
            );

            guiaEntrada.AsignarId(guiaEntradaId);

            int index = 0;
            foreach (var d in guiaEntrada.Detalles)
            {
                var detalleId = await _dapperCommandService.ExecuteScalarAsync(
                    "uspSetDetalleGuiaEntrada",
                    new
                    {
                        pOpcion = d.Id == 0 ? (int)OperationType.Create : (int)OperationType.Update,
                        pId = d.Id,
                        pIdGuiaEntrada = guiaEntradaId,
                        pIdProducto = d.IdProducto,
                        pIdUnidadMedida = d.IdUnidadMedida,
                        //pIdTalla = d.IdTalla,
                        pCantidad = d.Cantidad,
                        pNumCaja = d.NumCaja,
                        pCodigoEstilo = d.CodigoEstilo,
                        pCodigoPedido = d.CodigoPedido
                    });

                guiaEntrada.AsignarIdDetalle(index, detalleId, guiaEntradaId);
                index++;
            }

            return guiaEntrada;
        }

        public async Task<GuiaEntradaEntity> CrearGuiaEntradaAsync(
            GuiaEntradaEntity guiaEntrada
        )
        {
            var parameters = new
            {
                pOpcion = (int)OperationType.Create,

                pId = guiaEntrada.Id,
                pSerie = guiaEntrada.Serie,
                pNumero = guiaEntrada.Numero,
                pFecha = guiaEntrada.Fecha,
                pHora = guiaEntrada.Hora,
                pTipoGuia = guiaEntrada.TipoGuia,
                pIdProveedor = guiaEntrada.IdProveedor,
                pObservacion = guiaEntrada.Observacion,
                pTotalCantidad = guiaEntrada.TotalCantidad,
                pIdUsuario = guiaEntrada.IdUsuario,
            };

            var guiaEntradaId = await _dapperCommandService.ExecuteScalarAsync(
                "uspSetGuiaEntrada",
                parameters
            );

            guiaEntrada.AsignarId(guiaEntradaId);

            int index = 0;
            foreach (var d in guiaEntrada.Detalles)
            {
                var detalleId = await _dapperCommandService.ExecuteScalarAsync(
                    "uspSetDetalleGuiaEntrada",
                    new
                    {
                        pOpcion = (int)OperationType.Create,
                        pId = 0,
                        pIdGuiaEntrada = guiaEntradaId,
                        pIdProducto = d.IdProducto,
                        pIdUnidadMedida = d.IdUnidadMedida,
                        pCantidad = d.Cantidad,
                        pCodigoEstilo = d.CodigoEstilo,
                        pCodigoPedido = d.CodigoPedido,
                        pNumCaja = d.NumCaja
                    });

                guiaEntrada.AsignarIdDetalle(index, detalleId, guiaEntradaId);
                index++;
            }

            return guiaEntrada;
        }

        public async Task<int> EliminarDetalleEntradaAsync(DetalleGuiaEntradaEntity guiaEntrada)
        {
            var parameters = new
            {
                pOpcion = (int)OperationType.Delete,
                pId = guiaEntrada.Id,
                pIdUsuario = guiaEntrada.IdUsuario
            };

            int response = await _dapperCommandService.ExecuteScalarAsync("uspSetDetalleGuiaEntrada", parameters);
            return response;
        }


        public async Task<int> EliminarGuiaEntradaAsync(GuiaEntradaEntity guiaEntrada)
        {
            var parameters = new
            {
                pOpcion = (int)OperationType.Delete,
                pId = guiaEntrada.Id,
                pIdUsuario = guiaEntrada.IdUsuario
            };

            int response = await _dapperCommandService.ExecuteScalarAsync("uspSetGuiaEntrada", parameters);
            return response;
        }

        public async Task<List<DetalleGuiaEntradaDTO>> ObtenerDetalleGuiaEntradaPorIdGuiaAsync(int idGuiaEntrada)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdGuiaEntrada = idGuiaEntrada,
            };

            var response =
                await _dapperQueryService
                    .QueryAsync<DetalleGuiaEntradaDTO>("uspGetDetalleGuiaEntrada", parameters);

            return response?.ToList() ?? new List<DetalleGuiaEntradaDTO>(); 
        }

        public async Task<GuiaEntradaEntity> ObtenerGuiaEntradaPorIdAsync(int id)
        {
            var parameters = new
            {
                pOpcion = 2,
                pId = id
            };

            var response =
                await _dapperQueryService
                    .QueryFirstOrDefaultAsync<GuiaEntradaEntity>("uspGetGuiasEntrada", parameters);

            return response;
        }

        public async Task<PagedResult<GuiaEntradaDTO>> ObtenerGuiasEntradaAsync(
            ObtenerGuiasEntradaParams parametros
        )
        {
            var parameters = new
            {
                pOpcion = parametros.Opcion,

                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pOrdenPor = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,

                pSerie = parametros.Serie,
                pNumero = parametros.Numero,
                pIdProveedor = parametros.IdProveedor,
                pFechaDesde = parametros.FechaDesde,
                pFechaHasta = parametros.FechaHasta
            };

            var response = await _dapperQueryService
                                .QueryAsync<GuiaEntradaDTO>("uspGetGuiasEntrada", parameters);

            var guiasEntradaLista = response.ToList();
            var totalRegistros = guiasEntradaLista.FirstOrDefault()?.TotalRegistros ?? 0;

            return new PagedResult<GuiaEntradaDTO>
            {
                Data = guiasEntradaLista,
                Total = totalRegistros,
                Pagina = parametros.Pagina,
                FilasPorPagina = parametros.FilasPorPagina
            };
        }

        public async Task<GuiaEntradaDTO> ObtenerGuiaEntradaPorNumeroSerieAsync(
               ObtenerGuiasEntradaParams parametros
           )
        {
            var parameters = new
            {
                pOpcion = parametros.Opcion,
                pSerie = parametros.Serie,
                pNumero = parametros.Numero
            };

            var responseMulti = await _dapperQueryService.QueryMultipleAsync(
                "uspGetGuiasEntrada",
                async (multi) =>
                {
                    var guiaEntrada = await multi.ReadFirstOrDefaultAsync<GuiaEntradaDTO>();
                    if (guiaEntrada != null)
                    {
                        var detalleGuiaEntrada = await multi.ReadAsync<DetalleGuiaEntradaDTO>();
                        guiaEntrada.Detalles = detalleGuiaEntrada.ToList();
                    }
                    return guiaEntrada;
                },
                parameters
                , 0);

            return responseMulti;
        }

        public async Task<PagedResult<GuiaEntradaDTO>> ObtenerGuiasPendientesAprobarAsync(ObtenerGuiasPendientesAprobarParams parametros)
        {
            var parameters = new
            {
                pOpcion = parametros.Opcion,

                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pOrdenPor = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,

                pSerie = parametros.Serie,
                pNumero = parametros.Numero,
                pIdProveedor = parametros.IdProveedor,
                pFechaDesde = parametros.FechaDesde,
                pFechaHasta = parametros.FechaHasta
            };

            var response = await _dapperQueryService
                                .QueryAsync<GuiaEntradaDTO>("uspGetGuiasEntrada", parameters);

            var guiasEntradaLista = response.ToList();
            var totalRegistros = guiasEntradaLista.FirstOrDefault()?.TotalRegistros ?? 0;

            return new PagedResult<GuiaEntradaDTO>
            {
                Data = guiasEntradaLista,
                Total = totalRegistros,
                Pagina = parametros.Pagina,
                FilasPorPagina = parametros.FilasPorPagina
            };
        }
    }
}

