using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProductMenager : IUserProductService
    {
        IUserProductDal _userProductDal;

        public UserProductMenager(IUserProductDal userProductDal)
        {
            _userProductDal = userProductDal;
        }

        public UserProduct GetById(int id)
        {
            return _userProductDal.Get(x => x.UserID == id);
        }

        public List<UserProduct> GetUserProductList()
        {
          return  _userProductDal.List();
        }


       

        public void UserProductAdd(UserProduct userProduct)
        {
            throw new NotImplementedException();
        }

        public void UserProductDelete(UserProduct userProduct)
        {
            throw new NotImplementedException();
        }

        public void UserProductUpdate(UserProduct userProduct)
        {
            throw new NotImplementedException();
        }
    }
}
