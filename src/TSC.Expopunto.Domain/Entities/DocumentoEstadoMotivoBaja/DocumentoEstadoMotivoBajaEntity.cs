namespace TSC.Expopunto.Domain.Entities.DocumentoEstadoMotivoBaja
{
    public class DocumentoEstadoMotivoBajaEntity
    {
        public int Id { get; set; }
        public int? IdDocumentoEstado { get; set; }
        public int? IdMotivoBaja { get; set; }
        public string? Observacion { get; set; }

        public DocumentoEstadoMotivoBajaEntity()
        {

        }

        public DocumentoEstadoMotivoBajaEntity(
           int id,
           int? idDocumentoEstado,
           int? idMotivoBaja,
           string? observacion  
        )
        {
            this.Id = id;
            this.IdDocumentoEstado = idDocumentoEstado;
            this.IdMotivoBaja = idMotivoBaja;
            this.Observacion = observacion;
        }

        public void AsignarId(int id)
        {
            Id = id;
        }
    }
}
