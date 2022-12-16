using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;

namespace RecycleCoinProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        ProductInfoMenager pi = new ProductInfoMenager(new EfProductInfoDal());
        public ActionResult Index()
        {
            var productinfovalues = pi.GetProductInfoList();
            return View(productinfovalues);
        }
    }
}