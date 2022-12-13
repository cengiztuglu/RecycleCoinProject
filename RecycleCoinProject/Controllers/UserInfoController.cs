using BusinessLayer.Concrete;
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
        UserInfoMenager ui = new UserInfoMenager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUser()
        {
            var uservalues = ui.GetAll();
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
            ui.UserInfoAddBL(p);
            return RedirectToAction("GetUser");
        }
    }
}