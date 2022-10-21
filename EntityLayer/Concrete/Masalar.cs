using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Masalar
    {   [Key]
        public int MasaID { get; set; }
        [StringLength(50)]
        public string MasaAd { get; set; }
        public bool MasaDurum { get; set; }

        public ICollection<Siparisler> Siparislers { get; set; }

    }
}
