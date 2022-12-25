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
        List<UserProduct> GetUserInfoList();
        void UserInfoAdd(UserProduct userProduct);
        UserProduct GetById(int id);

        void UserInfoDelete(UserProduct userProduct);
        void UserInfoUpdate(UserProduct userProduct);
    }
}
