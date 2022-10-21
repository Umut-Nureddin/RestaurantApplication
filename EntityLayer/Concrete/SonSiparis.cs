using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class SonSiparis
    {  [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SipNo { get; set; }
    }
}
