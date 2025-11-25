namespace TSC.Expopunto.Application.DataBase.LineaCredito.Commands
{
    public class LineaCreditoCommand : ILineaCreditoCommand
    {
        public readonly IDapperCommandService _dapperService;
        public LineaCreditoCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<int> AplicarMontoConsumido(LineaCreditoModel model)
        {
            var parameter = new
            {
                pOpcion = 3,
                pId = model.Id,
                pMontoConsumido = model.MontoConsumido,
                pIdUsuario = model.IdUsuario
            };
            var respuesta = await _dapperService.ExecuteScalarAsync("uspSetLineasCredito", parameter);
            return respuesta;   
        }

        public async Task<int> DescontarMontoConsumido(LineaCreditoModel model)
        {
            var parameter = new
            {
                pOpcion = 4,
                pId = model.Id,
                pMontoConsumido = model.MontoConsumido,
                pIdUsuario = model.IdUsuario
            };
            var respuesta = await _dapperService.ExecuteScalarAsync("uspSetLineasCredito", parameter);
            return respuesta;
        }

        public async Task<int> ProcesarAsync(LineaCreditoModel model)
        {
            var parameter = new
            {
                pOpcion = model.Opcion,
                pId = model.Id,
                pMontoCredito = model.MontoCredito,
                pMontoConsumido = model.MontoConsumido,
                pIdUsuario = model.IdUsuario
            };
            var respuesta = await _dapperService.ExecuteScalarAsync("uspSetLineasCredito", parameter);
            return respuesta;
        }

    }
}
