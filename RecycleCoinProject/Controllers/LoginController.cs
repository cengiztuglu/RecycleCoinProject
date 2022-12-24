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
    public class LoginController : Controller
    {

        AdminLoginMenager alm = new AdminLoginMenager(new EfLoginDal());
       
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login P)
        {
            var adminuserinfo = alm.GetLogin(P.Email, P.Password, Convert.ToInt32(P.UserTypeID));
            if (adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.Email, false);//yetki verme işlemleri
                Session["Email"] = adminuserinfo.Email;

                return RedirectToAction("Index", "Product");
            }
         
      
            return View();
        }

      


    }
}