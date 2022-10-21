using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Odemeler
    {
        [Key]
        public int ID { get; set; }

        public int SipNo { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal Nakit { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal KrediKarti { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal Sodexo { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal Multinet { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal SipTutar { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal KalanTutar { get; set; }
        public bool OdemeDurum { get; set; }
        
    }
}
