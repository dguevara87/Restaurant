using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class OrdenProducto
    {
        public OrdenProducto() 
        {

        }
        [Key]
        [DataMember]
        public Guid Id { get; set; }
        
        public int Cantidad { get; set; }
        public Guid ProductoId { get; set; }
        public Guid OrdenId { get; set; }
        public Guid EstadoId { get; set; }
        public Guid? CentroElaboracionId { get; set; }

        [ForeignKey("OrdenId")]
        public virtual Orden Orden { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }

        [ForeignKey("EstadoId")]
        public virtual EstadoOrdenProducto EstadoOrdenProducto { get; set; }

        [ForeignKey("CentroElaboracionId")]
        public virtual CentrosElaboracion CentrosElaboracion { get; set; }
    }
}
