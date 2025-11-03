namespace TSC.Expopunto.Application.DataBase.LineaCredito.Commands
{
    public class LineaCreditoCommand : ILineaCreditoCommand
    {
        public readonly IDapperCommandService _dapperService;
        public LineaCreditoCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task ProcesarAsync(LineaCreditoModel model)
        {
            var parameter = new
            {
                pOpcion = model.Opcion,
                pId = model.Id,
                pMontoCredito = model.MontoCredito,
                pMontoConsumido = model.MontoConsumido,
                pIdUsuario = model.IdUsuario
            };
            await _dapperService.ExecuteScalarAsync("uspSetLineasCredito", parameter);
        }
    }
}
