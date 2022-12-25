using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductInfo
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
        public Nullable<int> ProductCarbon { get; set; }
        public bool ProductStatus { get; set; }
        public virtual ProductType productType { get; set; }
       

    }
}
