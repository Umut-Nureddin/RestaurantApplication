using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class StokHareketleri
    {
        [Key]
        public int HareketID { get; set; }
        public int UrunID { get; set; }
        [StringLength(100)]

        public string UrunAD { get; set; }
        public int? EklenenMiktar { get; set; }
        public int? CikanMiktar { get; set; }
        [StringLength(500)]

        public string? KayitNotu { get; set; }
        [Column(TypeName = "datetime")]

        public DateTime Zaman { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal? ToplamTutar { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal? BirimFiyat { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ZamanB { get; set; }//date olması lazım fromatı yyyy mm dd
        [Range(0, 9999999999999999.99)]

        public decimal? CikanTutar { get; set; }

    }
}
