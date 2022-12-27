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
            return _userProductDal.Get(x => x.ConvertID == id);
        }

        public List<UserProduct> GetUserProductList()
        {
          return  _userProductDal.List();
        }


       

        public void UserProductAdd(UserProduct userProduct)
        {
            _userProductDal.Insert(userProduct);
        }

        public void UserProductDelete(UserProduct userProduct)
        {
            userProduct.ProductStatus = true;
            _userProductDal.Update(userProduct);
        }

        public void UserProductUpdate(UserProduct userProduct)
        {
            userProduct.ProductStatus = false;
            _userProductDal.Update(userProduct);
        }
    }
}
