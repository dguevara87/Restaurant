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
    public partial class Reservas
    {
        public Reservas() 
        {
            Mesas = new HashSet<Mesas>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public int NumPersonas { get; set; }
        public string Reserva { get; set; }
        public Guid? EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        public virtual Empleado Empleado { get; set; }

        //[InverseProperty("Reservas")]
        public virtual ICollection<Mesas> Mesas { get; set; }
    }
}
