using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.Models;



namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries
{
    public class GuiaEntradaQuery : IGuiaEntradaQuery
    {
        private readonly IDapperQueryService _dapperService;

        public GuiaEntradaQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<List<GuiasEntradaTodosModel>> ListarTodosAsync()
        {
            var parameters = new
            {
                pOpcion = 1
            };
            var response = await _dapperService.QueryAsync<GuiasEntradaTodosModel>("uspGetGuiasEntrada",
            parameters);
            return response.ToList();
        }
        public async Task<GuiasEntradaTodosModel> ObtenerGuiaEntradaPorIdAsync(int idGuiaEntrada)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdGuiaEntrada = idGuiaEntrada
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<GuiasEntradaTodosModel>("uspGetGuiasEntrada",
            parameters);
            return response;
        }

    }

}
