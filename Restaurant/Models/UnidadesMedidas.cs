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
    public class UnidadesMedidas
    {
        public UnidadesMedidas()
        {
            Ingredientes = new HashSet<Ingrediente>();
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

        public virtual ICollection<Ingrediente> Ingredientes { get; set; }
    }
}
