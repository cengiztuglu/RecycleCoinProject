using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserProduct
    {
        [Key]
        public int ConvertID { get; set; }
        public int UserID { get; set; }  
        public int ProductBalance { get; set; }

        public string ProductName { get; set; }
        public Boolean ProductStatus{ get; set; }







    }
}
