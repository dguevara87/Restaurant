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
    public class CentrosElaboracion
    {
        public CentrosElaboracion() 
        {
            AreaCentroElab = new HashSet<AreaCentroElab>();
            OrdenesProductos = new HashSet<OrdenProducto>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = "campoRequerido")]
        [StringLength(30, ErrorMessageResourceName = "tamañoMaximo")]
        public string Nombre { get; set; }

        [Display(Name = "CentrosElaboracion")]
        [Required(ErrorMessageResourceName = "campoRequerido")]
        [StringLength(100, ErrorMessageResourceName = "tamañoMaximo")]
        public string Descripcion { get; set; }

        [InverseProperty("CentrosElaboracion")]
        public virtual ICollection<OrdenProducto> OrdenesProductos { get; set; }

        [InverseProperty("CentrosElaboracion")]
        public virtual ICollection<AreaCentroElab> AreaCentroElab { get; set; }
    }
}
