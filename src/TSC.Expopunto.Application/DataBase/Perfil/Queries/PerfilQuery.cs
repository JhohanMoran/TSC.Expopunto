using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Perfil.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Perfil.Queries
{
    public class PerfilQuery : IPerfilQuery
    {
        private readonly IDapperQueryService _dapperService;
        public PerfilQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<PerfilesTodosModel>> ListarComboPerfilesAsync()
        {
            var parameters = new
            {
                p_opcion = 2
            };

            var response = await _dapperService.QueryAsync<PerfilesTodosModel>("uspGetPerfiles", parameters);
            return response.ToList();
        }

        public async Task<PerfilesTodosModel> ListarPerfilesPorIdAsync(int idPerfil)
        {
            var parameters = new
            {
                p_opcion = 3,
                p_id = idPerfil
            };

            var response = await _dapperService.QueryFirstOrDefaultAsync<PerfilesTodosModel>("uspGetPerfiles", parameters);
            return response;
        }

        public async Task<List<PerfilesTodosModel>> ListarPerfilesPorEstadoAsync(bool? activo)
        {
            var parameters = new
            {
                p_opcion = 1,
                p_activo = activo
            };

            var response = await _dapperService.QueryAsync<PerfilesTodosModel>("uspGetPerfiles", parameters);
            return response.ToList();
        }
    }
}
