using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace RecycleCoinProject.Controllers
{

    [Authorize]
    public class AdminProductExchangeController : Controller
    {
        UserProductMenager upm = new UserProductMenager(new EfUserProductDal());
        // GET: AdminProductExchange
        public ActionResult UserProductExchange()
        {
            var userproductvalues = upm.GetUserProductList();
            return View(userproductvalues);
        }


        public ActionResult UserProductConfirmation(int id)
        {
                
            var userproductvalues = upm.GetById(id);
            upm.UserProductDelete(userproductvalues);
            return RedirectToAction("UserProductExchange");
        }
      public ActionResult UserProductReject(int id)
        {

            var userproductvalues = upm.GetById(id);
            upm.UserProductUpdate(userproductvalues);
            return  RedirectToAction("UserProductExchange");
        }
    }
}