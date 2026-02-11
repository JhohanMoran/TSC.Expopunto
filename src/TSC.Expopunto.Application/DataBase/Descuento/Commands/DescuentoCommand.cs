using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Descuento.Commands;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands;
using TSC.Expopunto.Common;

namespace TSC.Expopunto.Application.DataBase.Descuento.Commands
{
    public class DescuentoCommand : IDescuentoCommand
    {
        public readonly IDapperCommandService _dapperService;
        private readonly IDescuentoProductoVarianteCommand _detalleCommand;
        public DescuentoCommand(IDapperCommandService dapperService, IDescuentoProductoVarianteCommand detalleCommand)
        {
            _dapperService = dapperService;
            _detalleCommand = detalleCommand;
        }
        public async Task<DescuentoModel> ProcesarAsync(DescuentoModel model, List<DescuentoProductoVarianteModel> detalles = null)
        {

            var parameters = new
            {
                pOpcion = model.Opcion,
                pId = model.Id,
                pNombre = model.Nombre,
                pTipo = model.Tipo,
                pValor = model.Valor,
                pFechaInicio = model.FechaInicio,
                pFechaFin = model.FechaFin,
                pActivo = model.Activo,
                pIdUsuario = model.IdUsuario

            };
            var response = await _dapperService.ExecuteScalarAsync("uspSetDescuento", parameters);

            if (response > 0)
            {
                model.Id = response;
            }
            if (detalles != null && detalles.Count > 0)
            {
                foreach (var detalle in detalles)
                {
                    detalle.IdDescuento = model.Id;

                    
                        if (detalle.Id > 0)
                        {
                            detalle.Opcion = (int)OperationType.Update;
                        }
                        else
                        {
                            detalle.Opcion = (int)OperationType.Create;
                        }
                    

                    await _detalleCommand.ProcesarAsync(detalle);
                }
            }

            return model;
        }

    }
}
