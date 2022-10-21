using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Stoklar
    {
        [Key]
        public int StokID { get; set; }
        [StringLength(100)]
        public string UrunAd { get; set; }
        [StringLength(30)]

        public string Birim { get; set; }
        public int StokMiktari { get; set; }
        public int KritikStokMiktari { get; set; }
        public int UrunID { get; set; }

        public virtual Urunler Urunler { get; set; }
    }
}
