using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.Interfaces.Services
{
    public interface IDocumentoPdfService
    {
        byte[] GenerarPdf(ImpresionVentaDTO parametro);
        byte[] GenerarGuiaEntradaPdf(GuiaEntradaDTO parametro, List<ParametrosModel> dataEmpresa, PersonaTodosModel? dataProveedor, UsuariosTodosModel dataUsuario);
    }
}
