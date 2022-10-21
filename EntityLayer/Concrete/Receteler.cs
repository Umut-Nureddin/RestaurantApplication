using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Receteler
    {   [Key]
        public int ReceteID { get; set; }
        [StringLength(50)]
        public string StokUrun { get; set; }
        [StringLength(50)]

        public string Birim { get; set; }
        public int Miktar { get; set; }
        public int ReceteNo { get; set; }

        public int UrunID { get; set; }
        public virtual Urunler Urunler { get; set; }



    }
}
