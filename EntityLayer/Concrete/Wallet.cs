using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    internal class Wallet
    {
        public int UserID { get; set; }
        public Nullable<int> TotalCarbon { get; set; }

        public virtual Login Login { get; set; }
    }
}
