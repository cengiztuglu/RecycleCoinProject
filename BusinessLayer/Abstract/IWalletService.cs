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
        List<Wallet> GetProductInfoList();
        void ProductInfoAdd(Wallet wallet);
       Wallet GetById(int id);

        void ProductInfoDelete(Wallet wallet);
        void ProductInfoUpdate(Wallet wallet);
    }
}
