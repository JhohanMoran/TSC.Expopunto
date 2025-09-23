using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Parametro.Commands
{
    /// <summary>
    /// Maneja la actualización de parámetros usando Dapper y el procedimiento almacenado uspSetParametro.
    /// </summary>
    public class ParametroCommand : IParametroCommand
    {
        private readonly IDapperCommandService _dapperService;

        public ParametroCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<ParametroModel> ProcesarAsync(ParametroModel model)
        {
            try
            {
                var response = await _dapperService.ExecuteScalarAsync(
                    "uspSetParametro",
                    new
                    {
                        pOpcion = model.Opcion,
                        pId = model.Id,
                        pCodigo = model.Codigo,
                        pNombre = model.Nombre,
                        pValor = model.Valor,
                        pDescripcion = model.Descripcion,
                        pIdUsuario = model.IdUsuario
                    }
                );

                // Si el SP devuelve el Id actualizado, lo asignamos al modelo
                if (response > 0)
                {
                    model.Id = response;
                }

                return model;
            }
            catch (SqlException sqlEx)
            {
                // Captura errores de SQL Server (incluyendo RAISERROR desde el SP)
                throw new ArgumentException(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al procesar el parámetro: " + ex.Message);
            }
        }
    }
}



