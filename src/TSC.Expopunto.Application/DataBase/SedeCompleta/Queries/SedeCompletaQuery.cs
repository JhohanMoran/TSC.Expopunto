using Dapper;
using System.Data;
using TSC.Expopunto.Application.DataBase.SedeCompleta.Commands;
using TSC.Expopunto.Application.DataBase.SedeCompleta.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.SedeCompleta.Queries
{
    public class SedeCompletaQuery : ISedeCompletaQuery
{
    private readonly IDapperQueryService _dapperService;

    public SedeCompletaQuery(IDapperQueryService dapperService)
    {
        _dapperService = dapperService;
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