using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Kategori
    {   [Key]
        public int KategoriID { get; set; }
        [StringLength(50)]
        public string KategoriAD { get; set; }
    }
}
