using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace EntityLayer.Concrete
{
    public class Siparisler
    {
        [Key]
        public int SipID { get; set; }
        [StringLength(50)]
        public string MasaAD { get; set; }
        [StringLength(100)]


        public string UrunAd { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal UrunFiyat { get; set; }

        public int UrunAdet { get; set; }
        public bool SipDurum { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal SatirTutar { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal SiparisTutar { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Tarih { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal KDVTutar { get; set; }
        [Range(0, 9999999999999999.99)]

        public decimal AraTutar { get; set; }
        public int SipNo { get; set; }
        [StringLength(30)]

        public string? OdemeBicimi { get; set; }
        [Column(TypeName = "date")]

        public DateTime? TarihKasa { get; set; }
        public int UrunID { get; set; }
        public virtual Urunler Urunler { get; set; }
        public int MasaID { get; set; }
        public virtual Masalar Masalar { get; set; }

        public int? KullaniciID { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }

    }
}
