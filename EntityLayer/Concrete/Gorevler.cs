using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Gorevler

    {
        [Key]
        public int JobID { get; set; }
        [StringLength(50)]
        public string JobType { get; set; }
    }
}
