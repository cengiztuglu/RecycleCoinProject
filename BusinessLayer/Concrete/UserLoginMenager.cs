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
    public class UserLoginMenager : IUserLoginService
    {
        ILoginDal _loginDal;

        public UserLoginMenager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public Login GetUserLogin(string email, string password, int usertypeıd)
        {
            return _loginDal.Get(x => x.Email == email && x.Password == password && x.UserTypeID == 2);
        }
    }
}
