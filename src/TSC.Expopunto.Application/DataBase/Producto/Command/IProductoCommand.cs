namespace TSC.Expopunto.Application.DataBase.Producto.Command
{
    public interface IProductoCommand
    {
        Task<ProductoModel> ProcesarAsync(ProductoModel model);
    }
}
