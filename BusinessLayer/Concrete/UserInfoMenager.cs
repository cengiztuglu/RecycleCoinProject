using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstact
{
   public class UserInfoMenager:IUserInfoService
    {
        IUserInfoDal _userInfoDal;

        public UserInfoMenager(IUserInfoDal userInfoDal)
        {
            _userInfoDal = userInfoDal;
        }

        public UserInfo GetById(int id)
        {
            return _userInfoDal.Get(x => x.UserID == id);
        }

        public List<UserInfo> GetUserInfoList()
        {
            return _userInfoDal.List();
        }

        public void UserInfoAdd(UserInfo userInfo)
        {
            _userInfoDal.Insert(userInfo);
        }

        public void UserInfoDelete(UserInfo userInfo)
        {
            _userInfoDal.Delete(userInfo);
        }

        public void UserInfoUpdate(UserInfo userInfo)
        {
            _userInfoDal.Update(userInfo);
        }
    }
}
