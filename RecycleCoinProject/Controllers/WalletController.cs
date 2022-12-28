using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using RecycleCoinProject.ViewModel;

namespace RecycleCoinProject.Controllers
{
    public class WalletController : Controller
    {
        // GET: Wallet
        UserInfoMenager um = new UserInfoMenager(new EfUserInfoDal());
        UserProductMenager UserProductMenager = new UserProductMenager(new EfUserProductDal());
        WalletMenager walletMenager = new WalletMenager(new EfWalletDal());
        
        Context c = new Context();
        [HttpGet]
        public ActionResult Index(int id=0)
        {
            string p = (string)Session["Email"];
            TempData["var"] = p;


            UserProduct userProduct = new UserProduct();
         
           id = c.Logins.Where(x => x.Email == p).Select(y =>
            y.UserID).FirstOrDefault();
            var deger = um.GetById(id);
            int productcount = c.userProducts.Count(e => e.UserID == id && e.ProductStatus ==true);
            TempData["balance"] = deger.Balance;
            TempData["count"] = productcount;
            um.GetUserInfoList();


            return View();
        }

        [HttpPost]
        public ActionResult Index(string carbonvalue)
        {
            string mailinfo = (string)Session["Email"];
            var id = c.Logins.Where(x => x.Email == mailinfo).Select(y =>
            y.UserID).FirstOrDefault();
            int s1 = Convert.ToInt32(carbonvalue);
            
         
          
            var deger= um.GetById(id);
            double rcvalue= s1/ 100;
            var deger2= walletMenager.GetById(id);
             deger2.RcBalance += rcvalue;
           deger.Balance -= s1;

            walletMenager.WalletUpdate(deger2);
            um.UserInfoUpdate(deger);

            ViewBag.p = id;
            ViewBag.a = id;
            return RedirectToAction("Index");
        }


       
    
      







    }
}