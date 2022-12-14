
using BusinessLayer.Abstact;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecycleCoinProject.Controllers
{
    public class UserInfoController : Controller
    {
        UserInfoMenager ui = new UserInfoMenager(new EfUserInfoDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUser()
        {
            var uservalues = ui.GetUserInfoList();
            return View(uservalues);
        }
        [HttpGet]
        
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserInfo p)
        {
            //ui.UserInfoAddBL(p);
            return RedirectToAction("GetUser");
        }
    }
}