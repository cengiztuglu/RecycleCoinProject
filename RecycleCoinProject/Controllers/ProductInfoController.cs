using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecycleCoinProject.Controllers
{
    public class ProductInfoController : Controller
    {
        ProductInfoMenager ui = new ProductInfoMenager(new EfProductInfoDal());
        public ActionResult Index()
        {
            return View();
        }
    }
}