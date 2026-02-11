using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.TipoDocumento.Queries
{
    public class TipoDocumentoQuery : ITipoDocumentoQuery
    {
        private readonly IDapperQueryService _dapperService;

        public TipoDocumentoQuery(IDapperQueryService dapperBaseService)
        {
            _dapperService = dapperBaseService;
        }

        public async Task<List<TiposDocumentoTodosModel>> ListarTodosAsync()
        {
            var parameters = new { pOpcion = 1 };
            var response = await _dapperService.QueryAsync<TiposDocumentoTodosModel>(
                "uspGetTiposDocumento", parameters
            );
            return response.ToList();
        }

        public async Task<TiposDocumentoTodosModel> ObtenerTipoDocumentoPorIdAsync(int idTipoDocumento)
        {
            var parameters = new
            {
                pOpcion = 2,
                pIdTipoDocumento = idTipoDocumento
            };
            var response = await _dapperService.QueryFirstOrDefaultAsync<TiposDocumentoTodosModel>(
                "uspGetTiposDocumento", parameters
            );
            return response;
        }
    }


}
