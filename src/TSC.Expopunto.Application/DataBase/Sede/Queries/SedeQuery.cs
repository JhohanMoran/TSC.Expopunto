using Dapper;
using System.Data;
using TSC.Expopunto.Application.DataBase.Sede.Commands;
using TSC.Expopunto.Application.DataBase.Sede.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Sede.Queries
{
    public class SedeQuery : ISedeQuery
    {
        private readonly IDapperQueryService _dapperService;

        public SedeQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<SedesTodosModel>> ListarAsync(string? nombre = null)
        {
            var parameters = new
            {
                pOpcion = 1,
                pFiltroNombre = string.IsNullOrWhiteSpace(nombre) ? null : nombre
            };
            var response = await _dapperService.QueryAsync<SedesTodosModel>("uspGetSedes", parameters);
            return response.ToList();
        }

     
        public async Task<List<SedesTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 3
            };
            var response = await _dapperService.QueryAsync<SedesTodosModel>("uspGetSedes", parameters);
            return response.ToList();
        }

        public async Task<SedesTodosModel> ObtenerSedePorIdAsync(int idSede)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdSede = idSede
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<SedesTodosModel>("uspGetSedes", parameters);
            return response;
        }


        public async Task<List<SedeCompletaReporteModel>> ListarReporteAsync(string? nombre = null)
        {
            var parameters = new { pFiltroNombre = nombre };
            var response = await _dapperService.QueryAsync<SedeCompletaReporteModel>("uspGetSedesReporte", parameters);
            return response.ToList();
        }

        public async Task<SedeCompletaDetalleModel> ObtenerParaEditarAsync(int id)
        {
            using var connection = _dapperService.CreateConnection();

            using var multi = await connection.QueryMultipleAsync(
                "uspGetSedeCompletaById",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );

            var sede = await multi.ReadSingleOrDefaultAsync<SedeCompletaDetalleModel>();
            if (sede == null)
                throw new Exception($"Sede con ID {id} no encontrada o inactiva");

            var series = await multi.ReadAsync<SedeSerieItem>();
            sede.Series = series.ToList();

            return sede;
        }

    }
}
