using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Aprobar
{
    public class GuiaAprobacionCommand : IGuiaAprobacionCommand
    {
        public readonly IDapperCommandService _dapperService;
        public GuiaAprobacionCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task AprobarGuiasEntradaAsync(GuiaAprobacionModel model)
        {
            var parameter = new
            {
                pOpcion = model.Opcion,
                pIdGuiasConcat = model.IdGuiasConcat,
                pIdUsuario = model.IdUsuario
            };
            await _dapperService.ExecuteAsync("uspSetGuiasAprobacion", parameter);
        }
    }
}
