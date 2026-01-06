namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Aprobar
{
    public interface IGuiaAprobacionCommand
    {
        Task AprobarGuiasEntradaAsync(GuiaAprobacionModel model);
        Task GuiaConformidadSigeAsync(GuiaConformidadSigeModel model);
    }
}
