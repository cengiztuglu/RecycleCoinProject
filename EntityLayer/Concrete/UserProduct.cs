using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserProduct
    {


        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
       public virtual Login Login { get; set; }
        public virtual ProductType productType { get; set; }


    }
}
