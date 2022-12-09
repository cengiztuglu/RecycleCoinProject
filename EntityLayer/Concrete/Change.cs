using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Change
    {
        [Key]
        public int ConvertID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> ProccesDate { get; set; }

        public virtual Login Login { get; set; }
    }
}
