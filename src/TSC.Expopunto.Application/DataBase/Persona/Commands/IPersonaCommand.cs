namespace TSC.Expopunto.Application.DataBase.Persona.Commands
{
    public interface IPersonaCommand
    {
        Task<PersonaModel> ProcesarAsync(PersonaModel model);
    }
}
