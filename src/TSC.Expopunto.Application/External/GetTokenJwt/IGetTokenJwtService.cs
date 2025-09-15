namespace TSC.Expopunto.Application.External.GetTokenJwt
{
    public interface IGetTokenJwtService
    {
        string Execute(string idUsuario, string idPerfil);
    }
}
