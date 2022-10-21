using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class SiparisLog
    {   [Key]
        public int SipID { get; set; }
        [StringLength(50)]

        public string? MasaAD { get; set; }
        [Column(TypeName = "datetime")]

        public DateTime Tarih { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal SiparisTutar { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal KDVTutar { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal AraTutar { get; set; }

        public int MasaID { get; set; }

        public bool SipDurum { get; set; }
        public int? KullaniciID { get; set; }
        public int SipNo { get; set; }
        [StringLength(100)]

        public string UrunAd { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal UrunFiyat { get; set; }
        public int UrunAdet { get; set; }
        public int? EskiUrunAdet { get; set; }
        public int? EskiKullaniciID { get; set; }
        [StringLength(50)]

        public string? EskiMasaAD { get; set; }
        [StringLength(100)]

        public string? EskiUrunAd { get; set; }
        public bool? EskiSipDurum { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal? EskiSiparisTutar { get; set; }
        public int? TransactionID { get; set; }
    }
}
