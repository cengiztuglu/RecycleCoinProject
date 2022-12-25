using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserProductService
    {
        List<UserProduct> GetUserProductList();
        void UserProductAdd(UserProduct userProduct);
        UserProduct GetById(int id);

        void UserProductDelete(UserProduct userProduct);
        void UserProductUpdate(UserProduct userProduct);
    }
}
