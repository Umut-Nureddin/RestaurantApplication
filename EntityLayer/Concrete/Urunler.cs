using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }
        [StringLength(100)]

        public string UrunAD { get; set; }
        public int UrunKategoriID { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal UrunFiyat { get; set; }
        [StringLength(200)]

        public string? UrunResmi { get; set; }
        public bool StokDurum { get; set; }

        public ICollection<Receteler> Recetelers { get; set; }
        public ICollection<Stoklar> Stoklars { get; set; }
        public ICollection<Siparisler> Siparislers { get; set; }
    }
}
