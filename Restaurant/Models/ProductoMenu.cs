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
    public class ProductoMenu
    {
        public ProductoMenu() 
        {

        }

        [Key]
        public Guid Id { get; set; }
        public Guid? ProductoId { get; set; }
        public Guid? MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menus Menu { get; set; }
        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }
    }
}
