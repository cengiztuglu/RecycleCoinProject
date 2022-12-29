using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Wallet
    {
        [Key]
        [Required]
        public int UserID { get; set;  }
      
        [Required]
        public double  RcBalance { get; set; }

        [Required]
        public string Sha256 { get; set; }
       
       
    }
}
