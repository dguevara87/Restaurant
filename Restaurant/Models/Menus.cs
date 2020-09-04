using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public partial class Menus
    {
        public Menus()
        {
            ProductoMenu = new HashSet<ProductoMenu>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid? AreaId { get; set; }

        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }

        //[InverseProperty("Menus")]
        public virtual ICollection<ProductoMenu> ProductoMenu { get; set; }
    }
}
