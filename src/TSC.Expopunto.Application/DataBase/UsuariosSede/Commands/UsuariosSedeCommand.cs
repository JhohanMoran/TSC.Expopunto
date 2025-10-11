namespace TSC.Expopunto.Application.DataBase.UsuariosSede.Commands
{
    public class UsuariosSedeCommand : IUsuariosSedeCommand
    {
        public readonly IDapperCommandService _dapperService;
        public UsuariosSedeCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task ProcesarAsync(UsuariosSedeModel model)
        {
            var parameter = new
            {
                pOpcion = model.Opcion,
                pIdUsuario = model.IdUsuario,
                pIdSede = model.IdSede,
                pIdUsuarioProceso = model.IdUsuarioProceso
            };
            await _dapperService.ExecuteScalarAsync("uspSetUsuariosSede", parameter);
        }
    }
}
