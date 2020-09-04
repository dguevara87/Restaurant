using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class AreaCentroElab
    {
        public AreaCentroElab() 
        {

        }
        [Key]
        [DataMember]
        public Guid Id { get; set; }
        public Guid AreaId { get; set; }
        public Guid? CentroElaboracionId { get; set; }

        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }

        [ForeignKey("CentroElaboracionId")]
        public virtual CentrosElaboracion CentrosElaboracion { get; set; }
    }
}
