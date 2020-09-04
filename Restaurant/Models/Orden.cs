using System;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Models
{
    public class Orden
    {
        public Orden()
        {
            OrdenProductos = new HashSet<OrdenProducto>();
        }

        [Key]
        public Guid Id { get; set; }
        public decimal Importe { get; set; }
        public DateTime Creada { get; set; }
        public DateTime? Servida { get; set; }
        public DateTime? Cobrada { get; set; }
        public Guid EstadoId { get; set; }
        public Guid EsmpleadoId { get; set; }
        public Guid? MesaId { get; set; }


        [ForeignKey("EstadoId")]
        public virtual EstadoOrden EstadoOrden { get; set; }

        [ForeignKey("EmpleadoId")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("MesaId")]
        public virtual Mesas Nesa { get; set; }

        //[InverseProperty("Orden")]
        public virtual ICollection<OrdenProducto> OrdenProductos { get; set; }

    }
}
