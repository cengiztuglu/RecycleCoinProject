using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public class Proc
    {




        [Key]
        public int ProccesID { get; set; }
        public int UserID { get; set; }
        public System.DateTime ProccesDate { get; set; }
        public int TotalPrice { get; set; }
        public virtual Login Login { get; set; }
    }
}
