using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.Persona.Commands
{
    public class PersonaCommand : IPersonaCommand
    {
        private readonly IDapperCommandService _dapperService;

        public PersonaCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<PersonaModel> ProcesarAsync(PersonaModel model)
        {

            try
            {
                var response = await _dapperService.ExecuteScalarAsync(
                    "uspSetPersona",
                    new
                    {
                        pOpcion = model.Opcion,
                        pId = model.Id,
                        pCodTipoPersona = model.CodTipoPersona,
                        pIdTipoDocumento = model.IdTipoDocumento,
                        pNumeroDocumento = model.NumeroDocumento,
                        pRazonSocial = model.RazonSocial,
                        pNombres = model.Nombres,
                        pApellidos = model.Apellidos,
                        pDireccion = model.Direccion,
                        pCelular = model.Celular,
                        pIdUsuario = model.IdUsuario,
                        pActivo = model.Activo
                    }
                );

                if (response != null && Convert.ToInt32(response) > 0)
                {
                    model.Id = Convert.ToInt32(response);
                }

                return model;
            }
            catch (SqlException sqlEx)
            {
                // Capturamos errores de SQL Server (incluyendo RAISERROR)
                throw new ArgumentException(sqlEx.Message); // 👈 Esto será convertido en 400 por ExceptionManager
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al procesar la persona: " + ex.Message);
            }
        }
    }
}
