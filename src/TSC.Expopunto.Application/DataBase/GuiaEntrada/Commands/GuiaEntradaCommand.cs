using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Sede.Commands;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands
{
    public class GuiaEntradaCommand :IGuiaEntradaCommand
    {
        private readonly IDapperCommandService _dapperService;

        public GuiaEntradaCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<GuiaEntradaModel> ProcesarAsync(GuiaEntradaModel model)
        {
            var response = await _dapperService.ExecuteScalarAsync("uspSetGuiaEntrada",
                new
                {
                    pOpcion = model.Opcion,
                    pId     =model.Id,
                    pSerie = model.Serie,
                    pNumero = model.Numero,
                    pFecha = model.Fecha,
                    pIdPersonaProveedor = model.IdPersonaProveedor,
                    pTipoGuia = model.TipoGuia,
                    pObservacion= model.Observacion
                });
            if (response > 1)
            {
                model.Id = response;
            }
            return model;

        }
    }
}
