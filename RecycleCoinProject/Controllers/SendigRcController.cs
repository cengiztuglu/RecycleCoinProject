﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;

namespace RecycleCoinProject.Controllers
{
    public class SendigRcController : Controller
    {
        // GET: SendigRc
        UserInfoMenager um = new UserInfoMenager(new EfUserInfoDal());
        UserProductMenager UserProductMenager = new UserProductMenager(new EfUserProductDal());
        WalletMenager walletMenager = new WalletMenager(new EfWalletDal());
        Context c = new Context();

        
        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult Index(int id=0)
        {
            string p = (string)Session["Email"];
            TempData["var"] = p;

            UserProduct userProduct = new UserProduct();

            id = c.Logins.Where(x => x.Email == p).Select(y =>
             y.UserID).FirstOrDefault();
            var deger = um.GetById(id);
            var rcvalue  = c.Wallets.Where(x => x.UserID == id).Select(y =>
             y.RcBalance).FirstOrDefault();
            int productcount = c.userProducts.Count(e => e.UserID == id && e.ProductStatus == true);
            TempData["balance"] = deger.Balance;
            TempData["count"] = productcount;
            TempData["rcvalue"] = rcvalue;
            um.GetUserInfoList();


            return View();



        }
        [HttpPost]
        public ActionResult Index(string rcinput)
        {
          
            string mailinfo = (string)Session["Email"];
            var id = c.Logins.Where(x => x.Email == mailinfo).Select(y =>
         y.UserID).FirstOrDefault();
            double s1 = Convert.ToDouble(rcinput);
            
            var deger = walletMenager.GetById(id);
            
            Wallet wallet = new Wallet();
            deger.RcBalance -= s1;
       
          
           

          
            walletMenager.WalletUpdate(deger);
         


            ViewBag.p = id;
            ViewBag.a = id;
            return RedirectToAction("Index");

        }


    }
}