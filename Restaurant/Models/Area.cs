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
    public class Area
    {
        public Area() 
        {
            Mesas = new HashSet<Mesas>();
            Menus = new HashSet<Menus>();
            AreaCentroElab = new HashSet<AreaCentroElab>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = "campoRequerido")]
        [StringLength(30, ErrorMessageResourceName = "tamañoMaximo")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessageResourceName = "campoRequerido")]
        [StringLength(100, ErrorMessageResourceName = "tamañoMaximo")]
        public string Descripcion { get; set; }

        //[InverseProperty("Area")]
        public virtual ICollection<AreaCentroElab> AreaCentroElab { get; set; }

        //[InverseProperty("Area")]
        public virtual ICollection<Mesas> Mesas { get; set; }

        //[InverseProperty("Area")]
        public virtual ICollection<Menus> Menus { get; set; }
    }
}
