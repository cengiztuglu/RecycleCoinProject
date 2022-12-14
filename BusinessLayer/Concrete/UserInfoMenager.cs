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

        public List<UserInfo> GetUserInfoList()
        {
            return _userInfoDal.List();
        }
    
    }
}
