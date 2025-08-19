
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
            var response = await _dapperService.ExecuteScalarAsync("uspUsuarioProcesar",
                new
                {
                    p_opcion = model.opcion,
                    p_id = model.id,
                    p_nombres = model.nombres,
                    p_apellidos = model.apellidos,
                    p_usuario = model.usuario,
                    p_contrasenia = model.contrasenia
                });

            if (response > 1)
            {
                model.id = response;
            }

            return model;
        }
    }
}
