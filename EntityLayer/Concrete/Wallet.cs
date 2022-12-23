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
        public int UserID { get; set;  }

        public int? totalCarbon { get; set; }

        public int  RcBalance { get; set; }

        public virtual ICollection<Login> Logins { get; set; }

    }
}
