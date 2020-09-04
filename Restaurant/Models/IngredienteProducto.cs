using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class IngredienteProducto
    {
        public IngredienteProducto() 
        {

        }
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        public int Cantidad { get; set; }
        public Guid ProductoId { get; set; }
        public Guid IngredienteId { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }

        [ForeignKey("IngredienteId")]
        public virtual Ingrediente Ingrediente { get; set; }
    }
}
