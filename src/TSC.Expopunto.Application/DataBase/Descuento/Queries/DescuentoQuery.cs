using TSC.Expopunto.Application.DataBase.Descuento.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Descuento.Queries
{
    public class DescuentoQuery : IDescuentoQuery
    {
        private readonly IDapperQueryService _dapperService;
        public DescuentoQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<List<DescuentosTodosModel>> ListarDescuentosAsync(DescuentosListaParametros parametro)
        {
            var parameters = new
            {
                pOpcion = 1,
                pPagina = parametro.Pagina,
                pFilasPorPagina = parametro.FilasPorPagina,
                pOrdenPor = parametro.OrdenarPor,
                pOrdenDireccion = parametro.OrdenDireccion,

                pFiltroNombre = parametro.Nombre
            };

            var response = await _dapperService.QueryAsync<DescuentosTodosModel>("uspGetDescuentos", parameters);
            return response.ToList();

           
        }

        public async Task<List<DescuentosTodosModel>> ListarComboDescuentosAsync()
        {
            var parameters = new
            {
                pOpcion = 2
            };

            var response = await _dapperService.QueryAsync<DescuentosTodosModel>("uspGetDescuentos", parameters);
            return response.ToList();
        }

        public async Task<DescuentosTodosModel> ListarDescuentosPorIdAsync(int idDescuento)
        {
            var parameters = new
            {
                pOpcion = 3,
                pId = idDescuento
            };

            var filas = await _dapperService.QueryAsync<DescuentosTodosModel>("uspGetDescuentos", parameters);
            var listaFilas = filas.ToList();

            if (!listaFilas.Any())
                return null;

            var descuento = listaFilas.First();

            descuento.Detalles = listaFilas
                .Where(f => f.IdDetalle.HasValue && f.IdDetalle > 0)
                .Select(f => new DescuentosTodosModel
                {
                    Id = f.IdDetalle.Value,
                    IdDetalle = f.IdDetalle,
                    IdProductoVariante = f.IdProductoVariante,
                    CodProducto = f.CodProducto,
                    NombreProducto = f.NombreProducto,
                    Color = f.Color,
                    Talla = f.Talla,
                    ActivoDetalle = f.ActivoDetalle
                })
                .ToList();

            return descuento;

        }

        public async Task<List<DescuentosTodosModel>> ListarDescuentosPorEstadoAsync(bool? activo)
        {
            var parameters = new
            {
                pOpcion = 1,
                pActivo = activo
            };

            var response = await _dapperService.QueryAsync<DescuentosTodosModel>("uspGetDescuentos", parameters);
            return response.ToList();
        }

    }
}


