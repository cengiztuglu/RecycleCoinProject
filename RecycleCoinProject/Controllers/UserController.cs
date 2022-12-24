using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecycleCoinProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
           
        }
    }
}