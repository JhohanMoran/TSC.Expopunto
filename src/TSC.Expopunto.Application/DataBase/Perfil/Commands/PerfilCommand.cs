using Azure;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Perfil.Commands
{
    public class PerfilCommand : IPerfilCommand
    {
        public readonly IDapperCommandService _dapperService;
        public PerfilCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<PerfilModel> ProcesarAsync(PerfilModel model)
        {
            var response = await _dapperService.ExecuteScalarAsync("uspSetPerfil",
                    new
                    {
                        pOpcion = model.Opcion,
                        pId = model.Id,
                        pNombre = model.Nombre,
                        pDescripcion = model.Descripcion,
                        pIdUsuario = model.IdUsuario

                    }
                );

            if(response > 0)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
