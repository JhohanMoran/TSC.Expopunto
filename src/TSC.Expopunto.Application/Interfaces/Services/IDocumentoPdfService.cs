using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.Interfaces.Services
{
    public interface IDocumentoPdfService
    {
        byte[] GenerarPdf(VentaDTO parametro);
    }
}
