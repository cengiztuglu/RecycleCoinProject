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
    public class UserMenager : IUserService
    {
        IUserInfoDal _userInfoDal;
        public UserInfo GetById(int id)
        {
           return _userInfoDal.Get(x => x.UserID == id);
        }
      

        public UserMenager(IUserInfoDal userInfoDal)
        {
            _userInfoDal = userInfoDal;
        }

        public List<UserInfo> GetUserInfoList()
        {
            return _userInfoDal.List();
        }

        public void UserInfoAdd(UserInfo userInfo)
        {
          

        }

        public void UserInfoDelete(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public void UserInfoUpdate(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
