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
        private readonly IDapperQueryService _dapperQueryService;
        public GuiaAprobacionCommand(IDapperCommandService dapperService, IDapperQueryService dapperQueryService)
        {
            _dapperService = dapperService;
            _dapperQueryService = dapperQueryService;
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

        public async Task GuiaConformidadSigeAsync(GuiaConformidadSigeModel model)
        {
            var parameter = new
            {
                OPCION = model.Opcion,
                COD_ALMACEN = model.CodAlmacen,
                NUM_MOVSTK = model.NumMovstk
            };
            _dapperService.UsarConexion("SQLConnectionSigeMigraString");
            await _dapperService.ExecuteAsync("UP_GET_BANDEJA_EXPOPUNTO", parameter);
        }
    }
}
