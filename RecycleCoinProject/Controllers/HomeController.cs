using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Linq;

namespace RecycleCoinProject.Controllers
{
    public class HomeController : Controller
    {
        UserInfoMenager ui = new UserInfoMenager(new EfUserInfoDal());
        LoginRegisterMenager logm = new LoginRegisterMenager(new EfLoginDal());
        WalletMenager wm = new WalletMenager(new EfWalletDal());
        
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

                return RedirectToAction("UserProfile", "UserPanel");
            }
            else
            {

                { }


                return View();

            }
        }


        public ActionResult Register(string name,string surname, string phone,string email, string password)
        {


            UserInfo p = new UserInfo();
            Login log = new Login();
            Wallet wallet = new Wallet();
            p.Name = name;
            p.Surname = surname;
            p.PhoneNumber = phone;
            log.UserID =p.UserID;
            log.Email = email;
            log.Password = password;
            log.UserTypeID = 2;
            log.Role = "A";
            string convertSha = p.Name;
            string connection = "http://localhost:5000/api/blockchain/CreateSha256?convertsha=" + convertSha;
            XDocument xapidonus = XDocument.Load(connection);
            var xsha256 = xapidonus.Element("data").Element("sha").Value;
            string sha = xsha256;
            p.Sha256 = sha;
            wallet.Sha256 = sha;
            wallet.UserID = p.UserID;

            UserInfoValidatior userInfoValidatior = new UserInfoValidatior();
            LoginValidatior logval = new LoginValidatior();
            ValidationResult userresults = userInfoValidatior.Validate(p);
            ValidationResult logresults = logval.Validate(log);
            if (userresults.IsValid )
            {



                if (logresults.IsValid)
                {

                    logm.LoginInfoAdd(log);
                    ui.UserInfoAdd(p);
                    wm.WalletAdd(wallet);
                   
                }
                else
                {
                    foreach (var item in logresults.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }

              

            }
            else
            {
                foreach (var item in userresults.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return RedirectToAction("HomePage");
           
        }


    }
}