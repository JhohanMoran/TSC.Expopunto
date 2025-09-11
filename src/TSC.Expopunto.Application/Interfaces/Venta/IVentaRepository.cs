using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Application.Interfaces.Venta
{
    public interface IVentaRepository
    {
        // Procesos
        Task<int> CrearVentaAsync(VentaEntity venta);
        Task<int> ActualizarVentaAsync(VentaEntity venta);
        Task<int> EliminarVentaAsync(int id);

        // Listas
        Task<PagedResult<VentaDTO>> ObtenerVentasAsync(ObtenerVentasParams parametro);
        Task<VentaEntity> ObtenerVentaPorIdAsync(int id);
    }
}
