using TSC.Expopunto.Application.DataBase.Sede.Queries.Models;

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
            if (response != null && Convert.ToInt32(response) > 0)
            {
                model.Id = Convert.ToInt32(response);
            }

            return model;
        }
        public async Task<SedesTodosModel> ObtenerSedePorIdAsync(int idSede)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdSede = idSede
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<SedesTodosModel>("uspGetSedes", parameters);
            return response;
        }
    }
}
