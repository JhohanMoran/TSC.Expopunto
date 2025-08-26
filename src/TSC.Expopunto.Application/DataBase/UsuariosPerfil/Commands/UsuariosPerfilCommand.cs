using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.Features;

namespace TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands
{
    public class UsuariosPerfilCommand : IUsuariosPerfilCommand
    {
        public readonly IDapperCommandService _dapperService;
        private readonly IValidator<UsuariosPerfilModel> _validator;
        public UsuariosPerfilCommand(IDapperCommandService dapperService, IValidator<UsuariosPerfilModel> validator)
        {
            _dapperService = dapperService;
            _validator = validator;
        }
        public async Task ProcesarAsync(UsuariosPerfilModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            var parameter = new
            {
                pOpcion = model.Opcion,
                pIdUsuario = model.IdUsuario,
                pIdPerfil = model.IdPerfil,
                pIdUsuarioProceso = model.IdUsuarioProceso
            };
            await _dapperService.ExecuteScalarAsync("uspSetUsuariosPerfil", parameter);
        }
    }
}
