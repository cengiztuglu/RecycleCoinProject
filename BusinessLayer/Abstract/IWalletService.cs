using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWalletService
    {
        List<Wallet> WalletList();
        void WalletAdd(Wallet wallet);
       Wallet GetById(int id);

        void WalletDelete(Wallet wallet);
        void WalletUpdate(Wallet wallet);
    }
}
