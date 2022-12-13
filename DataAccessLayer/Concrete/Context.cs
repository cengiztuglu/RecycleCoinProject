using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Change> Changes { get; set; }

        public DbSet<PendigTransaction> PendigTransactions { get; set; }
        public DbSet<Proc> Procs { get; set; }

        public DbSet<ProductInfo> ProductInfos { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<User_Type> User_Types{ get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


    }
}
