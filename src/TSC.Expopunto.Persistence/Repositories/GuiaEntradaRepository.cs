using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Application.Interfaces.GuiaEntrada;
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
                pIdPersonaProveedor = guiaEntrada.IdPersonaProveedor,
                pTipoGuia = guiaEntrada.TipoGuia,
                pObservacion = guiaEntrada.Observacion
                
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
                        pIdTalla = d.IdTalla,
                        pCantidad = d.Cantidad,
                        pCostoUnitario = d.CostoUnitario
                        
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
                pIdPersonaProveedor = guiaEntrada.IdPersonaProveedor,
                pTipoGuia = guiaEntrada.TipoGuia,
                pObservacion = guiaEntrada.Observacion
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
                        pIdTalla = d.IdTalla,
                        pCantidad = d.Cantidad,
                        pCostoUnitario = d.CostoUnitario

                    
                    });

                guiaEntrada.AsignarIdDetalle(index, detalleId, guiaEntradaId);
                index++;
            }

            return guiaEntrada;
        }

        public async Task<List<DetalleGuiaEntradaDTO>> ObtenerDetalleGuiaEntradaPorIdVentaAsync(int idGuiaEntrada)
        {
            var parameters = new
            {
                pOpcion = 1,
                pIdGuiaEntrada = idGuiaEntrada,
            };

            var response =
                await _dapperQueryService
                    .QueryAsync<DetalleGuiaEntradaDTO>("uspGetDetalleGuiaEntrada", parameters);

            return response.ToList();
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
                pOpcion = 1,

                pPagina = parametros.Pagina,
                pFilasPorPagina = parametros.FilasPorPagina,
                pOrdenPor = parametros.OrdenarPor,
                pOrdenDireccion = parametros.OrdenDireccion,

                pSerie = parametros.Serie,
                pNumero = parametros.Numero
            };

            var response = await _dapperQueryService
                                .QueryAsync<GuiaEntradaDTO>("uspGetGuiasEntrada", parameters);

            var guiasEntradaLista = response.ToList();
            var totalRegistros = guiasEntradaLista.FirstOrDefault()?.TotalRegistros ?? 0;

            return new PagedResult<GuiaEntradaDTO>
            {
                Items = guiasEntradaLista,
                TotalRegistros = totalRegistros,
                Pagina = parametros.Pagina,
                FilasPorPagina = parametros.FilasPorPagina
            };
        }

    }
}

