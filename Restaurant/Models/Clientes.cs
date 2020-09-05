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
    public class Clientes
    {
        public Clientes()
        {
            Reservas = new HashSet<Reservas>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Identificacion { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Visitas { get; set; }
        public Guid? ClasificacionId { get; set; }

        [ForeignKey("ClasificacionId")]
        public virtual ClasificacionClientes Clasificacion { get; set; }


        public virtual ICollection<Reservas> Reservas { get; set; }

    }
}
