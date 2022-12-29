using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILoginRegisterService
    {
        List<Login> GetLoginİnfoList();
        void LoginInfoAdd(Login login);
        void LoginInfoUpdate(Login login);
        Login GetById(int id);

        void LoginInfoDelete(Login login);
    }
}
