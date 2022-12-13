using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
namespace BusinessLayer.Concrete
{
   public class UserInfoMenager
    {

        GenericRepository<UserInfo> repo = new GenericRepository<UserInfo>();
        public List<UserInfo> GetAll()
        {
            return repo.List();
        }
    
        public void UserInfoAddBL(UserInfo p)
        {
            if(p.Name==""|| p.Name.Length <=3|| p.Name.Length>20)
            {
              

            }
            else
            {
                repo.Insert(p);
                
            }
        }
    }
}
