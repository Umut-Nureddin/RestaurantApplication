using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Kullanicilar
    {
        [Key]
        public int KullaniciID { get; set; }
        [StringLength(60)]
        public string KullaniciAdSoyad { get; set; }
        [StringLength(20)]
        public string? Telefon { get; set; }
        [StringLength(40)]
        public string? Email { get; set; }
        public bool Yetki { get; set; }
        [StringLength(50)]
        public string GorevAd { get; set; }
        [StringLength(30)]
        public string KullaniciPassword { get; set; }
        public int KullaniciPin { get; set; }
        public bool? KullaniciDurum { get; set; }
        [StringLength(200)]
        public string? Aciklama { get; set; }

        public ICollection<Siparisler> Siparislers { get; set; }

    }
}
