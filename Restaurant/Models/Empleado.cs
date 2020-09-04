using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Empleado
    {
        public Empleado()
        {
            Ordenes = new HashSet<Orden>();
            Reservas = new HashSet<Reservas>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Identificacion { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        //[InverseProperty("Empleado")]
        public virtual ICollection<Orden> Ordenes { get; set; }

        //[InverseProperty("Empleado")]
        public virtual ICollection<Reservas> Reservas { get; set; }

    }
}
