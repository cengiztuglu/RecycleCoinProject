using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using DataAccessLayer.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete.Repositories;

namespace BusinessLayer.Concrete
{
    public class WalletMenager : IWalletService
    {
        IWalletDal _walletDal;
        public WalletMenager(IWalletDal walletDal)
        {
            _walletDal = walletDal;

        }
        public Wallet GetById(int id)
        {
            return _walletDal.Get(x => x.UserID == id);
        }

        public void WalletAdd(Wallet wallet)
        {
            _walletDal.Insert(wallet);

        }

        public void WalletDelete(Wallet wallet)
        {
            _walletDal.Delete(wallet);
        }

        public List<Wallet> WalletList()
        {
        return   _walletDal.List();
        }

        public void WalletUpdate(Wallet wallet)
        {
            _walletDal.Update(wallet);
        }
    }
}
