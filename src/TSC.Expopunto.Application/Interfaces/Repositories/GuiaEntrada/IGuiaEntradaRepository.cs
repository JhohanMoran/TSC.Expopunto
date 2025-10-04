using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada
{
    public interface IGuiaEntradaRepository
    {
        // Procesos
        Task<GuiaEntradaEntity> CrearGuiaEntradaAsync(GuiaEntradaEntity guiaEntrada);
        Task<GuiaEntradaEntity> ActualizarGuiaEntradaAsync(GuiaEntradaEntity guiaEntrada);


        // Listas
        Task<PagedResult<GuiaEntradaDTO>> ObtenerGuiasEntradaAsync(ObtenerGuiasEntradaParams parametro);
        Task<List<DetalleGuiaEntradaDTO>> ObtenerDetalleGuiaEntradaPorIdVentaAsync(int idGuiaEntrada);
        Task<GuiaEntradaEntity> ObtenerGuiaEntradaPorIdAsync(int id);
    }
}
