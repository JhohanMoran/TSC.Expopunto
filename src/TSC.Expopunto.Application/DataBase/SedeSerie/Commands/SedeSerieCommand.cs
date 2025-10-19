using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.SedeSerie.Commands
{
    public class SedeSerieCommand : ISedeSerieCommand
    {
        private readonly IDapperCommandService _dapperService;

        public SedeSerieCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<SedeSerieModel> ProcesarAsync(SedeSerieModel model)
        {
            var response = await _dapperService.ExecuteScalarAsync("uspSetSedeSerie",
                new
                {
                    pOpcion = model.Opcion,
                    pId = model.Id,
                    pIdSede = model.IdSede,
                    pIdTipoComprobante = model.IdTipoComprobante,
                    pSerie = model.Serie,
                    pIdUsuario = model.IdUsuario,
                    pActivo = model.Activo
                });

            //if (response > 0)
            //    model.Id = response;
            if (response != null && int.TryParse(response.ToString(), out int id))
                model.Id = id;
            return model;
        }
    }
}

