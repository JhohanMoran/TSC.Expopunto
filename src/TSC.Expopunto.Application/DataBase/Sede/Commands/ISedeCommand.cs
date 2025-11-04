namespace TSC.Expopunto.Application.DataBase.Sede.Commands
{
    public interface ISedeCommand
    {
        Task<SedeModel>ProcesarAsync(SedeModel model);
        Task<SedesTodosModel> ObtenerSedePorIdAsync(int idSede);
        Task ProcesarAsync(SedeCompletaModel model);


    }
}
