using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TSC.Expopunto.Domain.Entities.GuiaEntrada
{
    public class GuiaEntradaEntity
    {
        public int Id { get; set; }
        public string? Serie { get; set; }
        public string? Numero { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdPersonaProveedor { get; set; }
        public string? TipoGuia { get; set; }
        public string? Observacion { get; set; }


        private readonly List<DetalleGuiaEntradaEntity> _detalles = new();
        public IReadOnlyCollection<DetalleGuiaEntradaEntity> Detalles => _detalles;

        public GuiaEntradaEntity() { }

        public GuiaEntradaEntity(
            int id,
            string? serie,
            string? numero,
            DateTime? fecha,
            int? idPersonaProveedor,
            string? tipoGuia,
            string? observacion
        )
        {
            Id = id;
            Serie = serie;
            Numero = numero;
            Fecha = fecha;
            IdPersonaProveedor = idPersonaProveedor;
            TipoGuia = tipoGuia;
            Observacion = observacion;
        }
        public void AgregarDetalle(
            int id,
            int idGuiaEntrada,
            int idProducto,
            int idUnidadMedida,
            int idTalla,
            int cantidad,
            decimal costoUnitario
            
        )
        {
            _detalles.Add(new DetalleGuiaEntradaEntity(
                id,
                idGuiaEntrada,
                idProducto,
                idUnidadMedida,
                idTalla,
                cantidad,
                costoUnitario
                
            ));
        }

        public void Actualizar(
            int id,
            string? serie,
            string? numero,
            DateTime? fecha,
            int? idPersonaProveedor,
            string? tipoGuia,
            string? observacion,
            List<DetalleGuiaEntradaEntity>? nuevosDetalles
        )
        {
            Id = id;
            Serie = serie;
            Numero = numero;
            Fecha = fecha;
            IdPersonaProveedor = idPersonaProveedor;
            TipoGuia = tipoGuia;
            Observacion = observacion;
            

            _detalles.Clear();
            _detalles.AddRange(nuevosDetalles);
        }

        public void AsignarId(int id)
        {
            Id = id;
        }
        public void AsignarIdDetalle(int index, int idDetalle, int idGuiaEntrada)
        {
            if (index < 0 || index >= _detalles.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _detalles[index].AsignarId(idDetalle, idGuiaEntrada);
        }

    }
}
