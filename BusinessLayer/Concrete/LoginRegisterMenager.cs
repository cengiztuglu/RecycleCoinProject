using BusinessLayer.Abstact;
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
    public class LoginRegisterMenager : ILoginRegisterService
    {
        ILoginDal _loginDal;

        public LoginRegisterMenager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public Login GetById(int id)
        {
            return _loginDal.Get(x => x.UserID == id);
        }

        public List<Login> GetLoginİnfoList()
        {
           return _loginDal.List();
        }

        public void LoginInfoAdd(Login login)
        {
            _loginDal.Insert(login);
        }

        public void LoginInfoDelete(Login login)
        {
            _loginDal.Insert(login);
        }

        public void LoginInfoUpdate(Login login)
        {
            _loginDal.Delete(login);
        }
    }
}
