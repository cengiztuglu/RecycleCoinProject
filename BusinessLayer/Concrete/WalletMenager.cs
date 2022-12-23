using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WalletMenager : IWalletService
    {
        public Wallet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Wallet> GetProductInfoList()
        {
            throw new NotImplementedException();
        }


        public void ProductInfoAdd(Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public void ProductInfoDelete(Wallet walllet)
        {
            throw new NotImplementedException();
        }

        public void ProductInfoUpdate(Wallet wallet)
        {
            throw new NotImplementedException();
        }
    }
}
