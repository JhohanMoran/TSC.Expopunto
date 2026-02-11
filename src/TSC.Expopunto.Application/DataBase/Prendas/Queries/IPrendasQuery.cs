using TSC.Expopunto.Application.DataBase.Prendas.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Prendas.Queries
{
    public interface IPrendasQuery
    {
        Task<List<PrendasTodos>> ListarPaginadoStockAptAsync(PrendasParams param);
        Task<List<PrendasDatosClientes>> ListarClientesAsync();
        Task<List<PrendasDatosPedidos>> ListarPedidosAsync(string codigoCliente);
        Task<List<PrendasDatosEstiloClientes>> ListarEstilosClientesAsync(string pedido, string codigoCliente);
        Task<List<PrendasDatosPrensentaciones>> ListarPrensentacionesAsync(string pedido);
    }
}
