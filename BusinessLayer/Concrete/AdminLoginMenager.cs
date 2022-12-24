using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstact;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminLoginMenager : IAdminLoginService
    {
        ILoginDal _loginDal;


        public AdminLoginMenager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public Login GetLogin(string email, string password, int usertypeıd)
        {
            return _loginDal.Get(x => x.Email == email && x.Password == password && x.UserTypeID == 1);
        }
    }
    
}
