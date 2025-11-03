namespace TSC.Expopunto.Application.DataBase.PerfilMenu.Commands
{
    public class PerfilMenuModel
    {
        public int Opcion { get; set; }
        public int IdPerfil { get; set; }
        public int IdMenu { get; set; }
        public bool PuedeLeer { get; set; }
        public bool PuedeEscribir { get; set; }
        public int IdUsuarioProceso { get; set; }
    }
}
