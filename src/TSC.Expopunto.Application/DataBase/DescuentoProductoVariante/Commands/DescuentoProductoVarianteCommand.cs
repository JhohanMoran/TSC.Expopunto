using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands;

namespace TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands
{
    public class DescuentoProductoVarianteCommand : IDescuentoProductoVarianteCommand
    {
        private readonly IDapperCommandService _dapperService;

        public DescuentoProductoVarianteCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<DescuentoProductoVarianteModel> ProcesarAsync(DescuentoProductoVarianteModel model)
        {
            var parameters = new
            {
                pOpcion = model.Opcion,
                pId = model.Id,
                pIdDescuento = model.IdDescuento,
                pIdProductoVariante = model.IdProductoVariante,
                pActivo = model.Activo,
                pIdUsuario = model.IdUsuario
            };

            var response = await _dapperService.ExecuteScalarAsync("uspSetDescuentoProductoVariante", parameters);
            if (response > 0)
                model.Id = response;

            return model;
        }
    }
}
