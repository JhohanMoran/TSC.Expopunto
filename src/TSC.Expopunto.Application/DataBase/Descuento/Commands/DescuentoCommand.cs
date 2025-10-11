namespace TSC.Expopunto.Application.DataBase.Descuento.Commands
{
    public class DescuentoCommand : IDescuentoCommand
    {
        public readonly IDapperCommandService _dapperService;
        public DescuentoCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<DescuentoModel> ProcesarAsync(DescuentoModel model)
        {

            var parameters = new
            {
                pOpcion = model.Opcion,
                pId = model.Id,
                pNombre = model.Nombre,
                pTipo = model.Tipo,
                pValor = model.Valor,
                pFechaInicio = model.FechaInicio,
                pFechaFin = model.FechaFin,
                pActivo = model.Activo,
                pIdUsuario = model.IdUsuario

            };
            var response = await _dapperService.ExecuteScalarAsync("uspSetDescuento", parameters);

            if (response > 0)
            {
                model.Id = response;
            }

            return model;
        }

    }
}
