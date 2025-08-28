using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.EntidadFinanciera.Commands
{
    public class EntidadFinancieraCommand:IEntidadFinancieraCommand
    {
        private readonly IDapperCommandService _dapperService;


        //inyección de dependencias
        public EntidadFinancieraCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }


        public async Task<EntidadFinancieraModel> ProcesarAsync (EntidadFinancieraModel model)
        {
            

            var response = await _dapperService.ExecuteScalarAsync("uspSetEntidadesFinancieras",
                new
                {
                    pOpcion = model.Opcion,
                    pId = model.Id,
                    pCodigo = model.Codigo,
                    pDescripcion = model.Descripcion,
                    pIdEntidad = model.IdEntidad,
                    pActivo = model.Activo
                });

            if (response > 1)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
