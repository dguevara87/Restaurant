using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SIGECO2_DATAMODEL.Model;

namespace Restaurant.Models
{
    public partial class Productos
    {
        public Productos()
        {
            ProductoMenu = new HashSet<ProductoMenu>();
            OrdenesProductos = new HashSet<OrdenProducto>();
            IngredientesProductos = new HashSet<IngredienteProducto>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public Guid? EstadoId { get; set; }
        public Guid? ClasificacionId { get; set; }


        [ForeignKey("EstadoId")]
        public virtual EstadoProducto EstadoProducto { get; set; }
        [ForeignKey("ClasificacionId")]
        public virtual ClasificacionProducto ClasificacionProducto { get; set; }

        public virtual ICollection<ProductoMenu> ProductoMenu { get; set; }
        public virtual ICollection<OrdenProducto> OrdenesProductos { get; set; }
        public virtual ICollection<IngredienteProducto> IngredientesProductos { get; set; }
    }
}
