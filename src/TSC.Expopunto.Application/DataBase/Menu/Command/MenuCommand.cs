using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Menu.Command
{
    public class MenuCommand : IMenuCommand
    {
        private readonly IDapperCommandService _dapperSevice;

        public MenuCommand(IDapperCommandService dapperService)
        {
            _dapperSevice = dapperService;
        }
        public async Task<MenuModel> ProcesarAsync(MenuModel model)
        {
            var paremeters = new
            {
                p_opcion = model.Opcion,
                p_id = model.Id,
                p_nombre = model.Nombre,
                p_ruta = model.Ruta,
                p_icono = model.Icono,
                p_idMenuPadre = model.IdMenuPadre,
                p_orden = model.Orden,
                p_idUsuario = model.IdUsuario
            };

            var response = await _dapperSevice.ExecuteScalarAsync("uspSetMenu", paremeters);
            
            if(response > 0)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
