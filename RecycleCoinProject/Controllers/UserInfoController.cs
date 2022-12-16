
using BusinessLayer.Abstact;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            UserInfoValidatior cv = new UserInfoValidatior();
            ValidationResult results =cv.Validate(p);
            if (results.IsValid)
            {
                ui.UserInfoAdd(p);

                return RedirectToAction("GetUser");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
            
        }
      
    }
}