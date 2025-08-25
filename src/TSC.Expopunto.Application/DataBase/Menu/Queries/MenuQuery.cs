using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Menu.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Menu.Queries
{
    public class MenuQuery : IMenuQuery
    {
        private readonly IDapperQueryService _dapperService;

        public MenuQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<MenusTodos>> ListarMenusPorEstadoAsync(bool? activo)
        {
            var parameters = new
            {
                p_opcion = 1,
                p_activo = activo
            };
            var response = await _dapperService.QueryAsync<MenusTodos>("uspGetMenus", parameters);
            return response.ToList();
        }

        public async Task<MenusTodos> ListarMenusPorIdAsync(int idMenu)
        {
            var parameters = new
            {
                p_opcion = 3,
                p_id = idMenu
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<MenusTodos>("uspGetMenus", parameters);
            return response;
        }

        public async Task<List<MenusTodos>> ListarMenusSubMenusAsync()
        {
            var parameters = new
            {
                p_opcion = 2
            };
            var response = await _dapperService.QueryAsync<MenusTodos>("uspGetMenus", parameters);

            var menusFormateados = FormatearMenus(response.ToList());

            return menusFormateados;
            //return response.ToList();
        }

        public List<MenusTodos> FormatearMenus(List<MenusTodos> menus)
        {
            List<MenusTodos> menusPadres = menus.Where(m => m.IdMenuPadre == null).OrderBy(m => m.Orden).ToList();

            foreach(var menu in menusPadres)
            {
                menu.MenuHijo = ObtenerHijos(menus, menu.Id);
            }

            return menusPadres.ToList();
        }

        public List<MenusTodos> ObtenerHijos(List<MenusTodos> menus, int idPadre)
        {
            List<MenusTodos> menusHijos = menus.Where(m => m.IdMenuPadre == idPadre).OrderBy(m => m.Orden).ToList();

            foreach (var menu in menusHijos)
            {
                menu.MenuHijo = ObtenerHijos(menus, menu.Id);
            }

            return menusHijos.ToList();
        }
    }
}
