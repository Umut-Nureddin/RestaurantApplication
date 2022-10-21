using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Birim
    {   [Key]
        public int BirimID { get; set; }
        [StringLength(50)]
        public string BirimCins { get; set; }
    }
}
