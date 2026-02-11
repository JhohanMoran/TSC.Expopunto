namespace TSC.Expopunto.Domain.Entities.DocumentoEstado
{
    public class DocumentoEstadoEntity
    {
        public int Id { get; set; }
        public int? IdTipoProceso { get; set; }
        public int? IdReferencia { get; set; }
        public int? IdEstado { get; set; }
        public int? IdUsuario { get; set; }

        public DocumentoEstadoEntity() { }

        public DocumentoEstadoEntity(
            int id,
            int? idTipoProceso,
            int? idReferencia,
            int? idEstado,
            int? idUsuario
        )
        {
            this.Id = id;
            this.IdTipoProceso = idTipoProceso;
            this.IdReferencia = idReferencia;
            this.IdEstado = idEstado;
            this.IdUsuario = idUsuario;
        }

        public void AsignarId(int id)
        {
            Id = id;
        }
    }
}
