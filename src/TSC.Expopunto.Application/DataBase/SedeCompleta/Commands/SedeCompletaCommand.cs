using System.Text.Json;

namespace TSC.Expopunto.Application.DataBase.SedeCompleta.Commands
{
    public class SedeCompletaCommand : ISedeCompletaCommand
    {
        private readonly IDapperCommandService _dapperService;

        public SedeCompletaCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task ProcesarAsync(SedeCompletaModel model)
        {
            var jsonSeries = JsonSerializer.Serialize(model.Series);

            await _dapperService.ExecuteAsync("uspGuardarSedeCompleto", new
            {
                pIdSede = model.Id ?? (object?)null,
                pNombre = model.Nombre,
                pDireccion = model.Direccion,
                pIdUsuario = model.IdUsuario,
                pSeriesJson = jsonSeries,
                pActivo = model.Activo
            });
        }
    }
}