using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<UserInfo> GetUserInfoList();
        void UserInfoAdd(UserInfo userInfo);
        UserInfo GetById(int id);

        void UserInfoDelete(UserInfo userInfo);
        void UserInfoUpdate(UserInfo userInfo);
    }
}
