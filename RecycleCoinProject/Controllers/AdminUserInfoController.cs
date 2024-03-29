﻿
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using BusinessLayer.Concrete;
using System.Xml.Linq;

namespace RecycleCoinProject.Controllers
{
    public class AdminUserInfoController : Controller
    {
        UserInfoMenager ui = new UserInfoMenager(new EfUserInfoDal());
        public ActionResult Index()
        {
            var userinfovalues = ui.GetUserInfoList();
            return View(userinfovalues);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserInfo p)
        {

            string convertSha = p.Name ;
            string connection = "http://localhost:5000/api/blockchain/CreateSha256?convertsha=" + convertSha;
            XDocument xapidonus = XDocument.Load(connection);
            var xsha256 = xapidonus.Element("data").Element("sha").Value;
            string sha = xsha256;
            p.Sha256 = sha;
            UserInfoValidatior userInfoValidatior = new UserInfoValidatior();
            ValidationResult results = userInfoValidatior.Validate(p);
            if(results.IsValid)
            {
                
                ui.UserInfoAdd(p);
                return RedirectToAction("Index");
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
        public ActionResult DeleteUser(int id)
        {
            var uservalue = ui.GetById(id);
            ui.UserInfoDelete(uservalue);
            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var uservalue = ui.GetById(id);

            return View(uservalue);

        }
       [HttpPost]
      public ActionResult EditUser(UserInfo p)
        {
            ui.UserInfoUpdate(p);
            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult CuzdanUser(int id)
        {
            var uservalue = ui.GetById(id);

            return View(uservalue);

        }


    }
}