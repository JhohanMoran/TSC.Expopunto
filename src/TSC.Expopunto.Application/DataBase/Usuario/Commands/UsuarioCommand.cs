
namespace TSC.Expopunto.Application.DataBase.Usuario.Commands
{
    public class UsuarioCommand : IUsuarioCommand
    {
        private readonly IDapperCommandService _dapperService;

        public UsuarioCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<UsuarioModel> ProcesarAsync(UsuarioModel model)
        {
            var response = await _dapperService.ExecuteScalarAsync("uspSetUsuario",
                new
                {
                    pOpcion = model.Opcion,
                    pId = model.Id,
                    pNombres = model.Nombres,
                    pApellidos = model.Apellidos,
                    pUsuario = model.Usuario,
                    pContrasenia = model.Contrasenia
                });

            if (response > 1)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
