using DataAccessLayer.Concrete;
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
        [AllowAnonymous]
        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomePage(Login p)
        {
            Context c = new Context();
            var adminuserinfo = c.Logins.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password && x.UserTypeID==1);
            var userinfo = c.Logins.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password && x.UserTypeID == 2);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.Email, false);//yetki verme işlemleri
                Session["Email"] = adminuserinfo.Email;

                return RedirectToAction("Index", "Product");
            }
            else
            {

            }

            if (userinfo != null)
            {
               

                return RedirectToAction("Index", "User");
            }
            else
            {

            }



            return View();
        }
    }
}