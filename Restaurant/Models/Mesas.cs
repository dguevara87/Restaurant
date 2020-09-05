using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public partial class Mesas
    {
        public Mesas()
        {
            Ordenes = new HashSet<Orden>();
        }

        [Key]
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public Guid EstadoId { get; set; }
        public Guid? ReservaId { get; set; }

        [ForeignKey("EstadoId")]
        public virtual EstadoMesa EstadoMesa { get; set; }

        [ForeignKey("ReservaId")]
        public virtual Reservas Reserva { get; set; }

        //[InverseProperty("Orden")]
        public virtual ICollection<Orden> Ordenes { get; set; }
    
    }
}
