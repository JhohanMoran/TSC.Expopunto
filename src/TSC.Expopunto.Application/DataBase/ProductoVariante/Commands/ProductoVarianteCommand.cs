using TSC.Expopunto.Application.DataBase.ProductoVariante.Commands.Models;

namespace TSC.Expopunto.Application.DataBase.ProductoVariante.Commands
{
    public class ProductoVarianteCommand : IProductoVarianteCommand
    {
        private readonly IDapperCommandService _dapperCommandService;

        public ProductoVarianteCommand(IDapperCommandService dapperCommandService)
        {
            this._dapperCommandService = dapperCommandService;
        }
        public async Task<ProductoVarianteModel> ProcesarAsync(ProductoVarianteModel param)
        {
            var parametros = new
            {
                pOpcion = param.Opcion,
                pTalla = param.Talla,
                pColor = param.Color,
                pIdProducto = param.IdProducto,
                pCodigoSku = param.CodigoSKU
            };

            int response = await this._dapperCommandService.ExecuteScalarAsync("uspSetProductoVariante", parametros);
            param.Id = response;

            return param;
        }
    }
}
