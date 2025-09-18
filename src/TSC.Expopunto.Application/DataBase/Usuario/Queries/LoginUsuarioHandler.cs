using MediatR;
using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;
using TSC.Expopunto.Application.External.GetTokenJwt;
using TSC.Expopunto.Application.Security;

namespace TSC.Expopunto.Application.DataBase.Usuario.Queries
{
    public class LoginUsuarioHandler : IRequestHandler<LoginUsuarioQuery, RespuestaLoginModel>
    {
        private readonly IPasswordService _passwordService;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IGetTokenJwtService _getTokenJwtService;

        public LoginUsuarioHandler(
            IPasswordService passwordService,
            IUsuarioQuery usuarioQuery,
            IGetTokenJwtService getTokenJwtService
        )
        {
            _passwordService = passwordService;
            _usuarioQuery = usuarioQuery;
            _getTokenJwtService = getTokenJwtService;
        }

        public async Task<RespuestaLoginModel> Handle(LoginUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioQuery.ObtenerUsuarioPorUsuarioAsync(request.Usuario);

            if (usuario is null)
                throw new KeyNotFoundException($"Usuario no encontrado");

            // 2. Verificar la contraseña
            bool passwordOk = _passwordService.VerifyPassword(request.Contrasena, usuario.Contrasena);


            if (!passwordOk)
            {
                throw new UnauthorizedAccessException("La contraseña es incorrecta");
            }
            else
            {
                // Generar el token JWT
                usuario.Token = _getTokenJwtService.Execute(request.idPerfil.ToString(), usuario.IdUsuario.ToString());
                usuario.Contrasena = ""; // Limpiar la contraseña antes de devolver el objeto 
                usuario.IdPerfil = request.idPerfil;
            }

            return usuario;
        }
    }
}
