using System;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;
using SIGECO2_DATAMODEL.Model;

namespace Restaurant.Models
{
    public class Ingrediente
    {
        public Ingrediente() 
        {
            IngredientesProductos = new HashSet<IngredienteProducto>();
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
        
        public decimal Existencia { get; set; }
        
        public Guid? UnidadMedidaId { get; set; }
        
        public Guid? ClasificacionId { get; set; }
        
        [ForeignKey("UnidadMedidaId")]
        public virtual UnidadesMedidas UnidadMedida { get; set; }

        [ForeignKey("ClasificacionId")]
        public virtual ClasificacionIngrediente ClasificacionIngrediente { get; set; }

        public virtual ICollection<IngredienteProducto> IngredientesProductos { get; set; }
    }
}
