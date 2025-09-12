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
                pNombre = model.Nombre,
                pDescripcion = model.Descripcion,
                pIdCategoria = model.IdCategoria,
                pIdUsuario = model.IdUsuario
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
