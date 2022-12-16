using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstact
{
    internal interface IUserInfoService
    {
        List<UserInfo> GetUserInfoList();
        void UserInfoAdd(UserInfo userInfo);
        UserInfo GetById(int id);

        void UserInfoDelete(UserInfo userInfo);
        void UserInfoUpdate(UserInfo userInfo);
    }
}
