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

        public List<UserProduct> GetUserInfoList()
        {
          return  _userProductDal.List();
        }

        public void UserInfoAdd(UserProduct userProduct)
        {

            _userProductDal.Insert(userProduct);
        }

        public void UserInfoDelete(UserProduct userProduct)
        {
            _userProductDal.Delete(userProduct);
        }

        public void UserInfoUpdate(UserProduct userProduct)
        {
            _userProductDal.Update(userProduct);
        }
    }
}
