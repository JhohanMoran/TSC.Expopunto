namespace TSC.Expopunto.Application.DataBase.Parametro.Commands
{
    public class ParametroModel
    {
        // Indica la operación: en este caso 2 = Actualizar
        public int Opcion { get; set; } = 2;

        // Id del registro a actualizar
        public int Id { get; set; }

        // Campos editables en la tabla Parametros
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // Usuario que realiza la acción
        public int IdUsuario { get; set; }
    }
}


