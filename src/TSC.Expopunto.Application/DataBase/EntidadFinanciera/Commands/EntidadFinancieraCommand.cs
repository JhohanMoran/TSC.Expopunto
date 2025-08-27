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
                    p_opcion = model.opcion,
                    p_id = model.id,
                    p_codigo = model.codigo,
                    p_descripcion = model.descripcion,
                    p_idUsuario = model.idUsuario,
                    p_activo = model.activo
                });

            if (response > 1)
            {
                model.id = response;
            }

            return model;
        }
    }
}
