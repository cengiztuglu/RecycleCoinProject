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
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login P)
        {
            Context c = new Context();
            var adminuserinfo = c.Logins.FirstOrDefault(x => x.Email == P.Email && x.Password == P.Password);
            if (adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.Email, false);//yetki verme işlemleri
                Session["Email"] = adminuserinfo.Email;

                return RedirectToAction("Index", "Product");
            }
            else
            {

            }
            return View();
        }
    }
}