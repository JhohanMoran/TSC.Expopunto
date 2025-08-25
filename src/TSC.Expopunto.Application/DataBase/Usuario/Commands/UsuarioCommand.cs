
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
                    p_opcion = model.Opcion,
                    p_id = model.Id,
                    p_nombres = model.Nombres,
                    p_apellidos = model.Apellidos,
                    p_usuario = model.Usuario,
                    p_contrasenia = model.Contrasenia
                });

            if (response > 1)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
