using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Commands;

namespace TSC.Expopunto.Application.DataBase.Persona.Commands
{
    public class PersonaCommand:IPersonaCommand
    {
        private readonly IDapperCommandService _dapperService;


        //inyección de dependencias
        public PersonaCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }


        public async Task<PersonaModel> ProcesarAsync(PersonaModel model)
        {


            var response = await _dapperService.ExecuteScalarAsync("uspSetPersonas",
                new
                {

                    pOpcion =model.Opcion,
                    pId =model.Id,
                    pCodTipoPersona =model.CodTipoPersona,
                    pIdTipoDocumento =model.IdTipoDocumento,
                    pNumeroDocumento =model.NumeroDocumento,
                    pRazonSocial =model.RazonSocial,
                    pNombres =model.Nombres,
                    pApellidos=model.Apellidos,
                    pDireccion =model.Direccion,
                    pCelular =model.Celular,
                    pIdUsuario =model.IdUsuario
                });

            if (response > 1)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
