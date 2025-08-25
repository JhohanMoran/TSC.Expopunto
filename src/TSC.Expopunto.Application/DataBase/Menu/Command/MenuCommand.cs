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
                pOpcion = model.Opcion,
                pId = model.Id,
                pNombre = model.Nombre,
                pRuta = model.Ruta,
                pIcono = model.Icono,
                pIdMenuPadre = model.IdMenuPadre,
                pOrden = model.Orden,
                pIdUsuario = model.IdUsuario
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
