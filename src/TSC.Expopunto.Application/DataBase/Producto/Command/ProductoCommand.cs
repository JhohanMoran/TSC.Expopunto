namespace TSC.Expopunto.Application.DataBase.Producto.Command
{
    public class ProductoCommand : IProductoCommand
    {
        private readonly IDapperCommandService _dapperCommandSevice;

        public ProductoCommand(IDapperCommandService dapperCommandService)
        {
            _dapperCommandSevice = dapperCommandService;
        }
        public async Task<ProductoModel> ProcesarAsync(ProductoModel model)
        {
            var parameters = new
            {
                pOpcion = model.Opcion,
                pId = model.Id,
                pIdCategoria = model.IdCategoria,
                pCodProducto =model.CodProducto,
                pNombre = model.Nombre,
                pGenero =model.Genero,
                pIdUsuario = model.IdUsuario,
                pActivo = model.Activo
            };

            var response = await _dapperCommandSevice.ExecuteScalarAsync("uspSetProducto", parameters);

            if (response > 0)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
