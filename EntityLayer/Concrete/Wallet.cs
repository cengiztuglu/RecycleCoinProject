using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Wallet
    {
        [Key]
        public int UserID { get; set; }
        public Nullable<int> totalCarbon { get; set; }

        public virtual ICollection<Login>  Logins { get; set;}
    }
}
