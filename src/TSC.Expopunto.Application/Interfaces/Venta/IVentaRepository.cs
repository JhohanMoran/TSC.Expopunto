using TSC.Expopunto.Application.DataBase.DetalleVenta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentas.Params;
using TSC.Expopunto.Application.DataBase.VentasFormaPago.DTO;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.Venta;

namespace TSC.Expopunto.Application.Interfaces.Venta
{
    public interface IVentaRepository
    {
        // Procesos
        Task<VentaEntity> CrearVentaAsync(VentaEntity venta);
        Task<VentaEntity> ActualizarVentaAsync(VentaEntity venta);
        Task<int> EliminarVentaAsync(int id, int idUsuario);

        // Listas
        Task<PagedResult<VentaDTO>> ObtenerVentasAsync(ObtenerVentasParams parametro);
        Task<List<DetalleVentaDTO>> ObtenerDetalleVentaPorIdVentaAsync(int idVenta);
        Task<VentaEntity> ObtenerVentaPorIdAsync(int id);
        Task<List<VentaMontoDTO>> ObtenerVentasPorIdPersonaAsync(int id);
        Task<List<VentasFormaPagoDTO>> ObtenerVentasFormaPagoPorIdVentaAsync(int idVenta);

    }
}
