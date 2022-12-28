using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EntityLayer.Concrete
{
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        public string Sha256 { get; set; }
        public virtual Login Login { get; set; }
        public double Balance { get; set; }
     

    }
}
