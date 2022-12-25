using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Login
    {
        /*  public Login()
          {
              this.Changes = new HashSet<Change>();
              this.Procs = new HashSet<Proc>();
          }
          public int UserID { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public int UserTypeID { get; set; }
          public virtual User_Type User_Type { get; set; }
          public virtual ICollection<Change> Changes { get; set; }
          public virtual ICollection<Proc> Procs { get; set; }
          public virtual UserInfo UserInfo { get; set; }*/


        public Login()
        {
            this.Changes = new HashSet<Change>();
            this.Procs = new HashSet<Proc>();
            this.UserProducts = new HashSet<UserProduct>();
            
        }
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Nullable<int> UserTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Change> Changes { get; set; }
        public virtual User_Type User_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proc> Procs { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<UserProduct> UserProducts { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }




    }
}
