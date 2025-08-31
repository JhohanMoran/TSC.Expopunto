using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Sede.Commands
{
    public class SedeCommand : ISedeCommand
    {
        private readonly IDapperCommandService _dapperService;

        //Inyeccion de dependencia
        public SedeCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<SedeModel> ProcesarAsync(SedeModel model)
        {
            var response = await _dapperService.ExecuteScalarAsync("uspSetSede",
                new
                {
                    pOpcion = model.Opcion,
                    pId = model.Id,
                    pNombre = model.Nombre,
                    pDireccion = model.Direccion,
                    pIdUsuario = model.IdUsuario,
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
