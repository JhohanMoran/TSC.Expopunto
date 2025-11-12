namespace TSC.Expopunto.Domain.Entities.DocumentoEstadoBaja
{
    public class DocumentoEstadoBajaEntity
    {
        public int Id { get; set; }
        public int? IdDocumentoEstado { get; set; }
        public int? IdUsuario { get; set; }

        public DocumentoEstadoBajaEntity()
        {

        }

        public DocumentoEstadoBajaEntity(
           int id,
           int? idDocumentoEstado,
           int? idUsuario
        )
        {
            this.Id = id;
            this.IdDocumentoEstado = idDocumentoEstado;
            this.IdUsuario = idUsuario;
        }

        public void AsignarId(int id)
        {
            Id = id;
        }
    }
}
