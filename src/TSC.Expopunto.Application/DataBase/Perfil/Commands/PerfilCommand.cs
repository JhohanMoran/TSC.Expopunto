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
                        p_opcion = model.Opcion,
                        p_id = model.Id,
                        p_nombre = model.Nombre,
                        p_descripcion = model.Descripcion,
                        p_idUsuario = model.IdUsuario

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
