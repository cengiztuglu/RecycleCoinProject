using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace RecycleCoinProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        UserLoginMenager ulm = new UserLoginMenager(new EfLoginDal());
        [AllowAnonymous]
        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(Login p)
        {
          
           
                var adminuserinfo = ulm.GetUserLogin(p.Email, p.Password, Convert.ToInt32(p.UserTypeID));
                if (adminuserinfo != null)
                {
                    FormsAuthentication.SetAuthCookie(adminuserinfo.Email, false);//yetki verme işlemleri
                    Session["Email"] = adminuserinfo.Email;

                    return RedirectToAction("Index", "User");
                }


                return View();
            
        }
    }
}