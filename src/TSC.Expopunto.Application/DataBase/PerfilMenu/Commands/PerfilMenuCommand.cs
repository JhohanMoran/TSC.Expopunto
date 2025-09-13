using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.PerfilMenu.Commands
{
    public class PerfilMenuCommand : IPerfilMenuCommand
    {
        public readonly IDapperCommandService _dapperService;
        //private readonly IValidator<PerfilMenuModel> _validator;
        public PerfilMenuCommand(IDapperCommandService dapperService
            //, IValidator<PerfilMenuModel> validator
            )
        {
            _dapperService = dapperService;
            //_validator = validator;
        }
        public async Task ProcesarAsync(PerfilMenuModel model)
        {
            //var result = await _validator.ValidateAsync(model);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            var parameter = new
            {
                pOpcion = model.Opcion,
                pIdPerfil = model.IdPerfil,
                pIdMenu = model.IdMenu,
                pPuedeLeer = model.PuedeLeer,
                pPuedeEscribir = model.PuedeEscribir,
                pIdUsuarioProceso = model.IdUsuarioProceso
            };
            await _dapperService.ExecuteScalarAsync("uspSetPerfilesMenu", parameter);
        }
    }
}
