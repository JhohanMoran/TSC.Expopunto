using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoDocumento.Queries
{
    public interface ITipoDocumentoQuery
    {
        Task<List<TiposDocumentoTodosModel>> ListarTodosAsync();
        Task<TiposDocumentoTodosModel> ObtenerTipoDocumentoPorIdAsync(int idTipoDocumento);
    }
}
