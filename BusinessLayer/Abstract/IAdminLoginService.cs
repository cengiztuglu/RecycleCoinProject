using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstact
{
    public interface IAdminLoginService
    {
        Login GetLogin(string email, string password, int usertypeıd);
       
    }
}
