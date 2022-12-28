using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using FluentValidation;
using RecycleCoinProject.ViewModel;

namespace RecycleCoinProject.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: User

        UserInfoMenager um = new UserInfoMenager(new EfUserInfoDal());
        UserProductMenager upm = new UserProductMenager(new EfUserProductDal());
        ProductInfoMenager pi = new ProductInfoMenager(new EfProductInfoDal());
        ProductTypeMenager pt = new ProductTypeMenager(new EfProductTypeDal());
      
        Context c = new Context();

        [HttpGet]
        public ActionResult UserProfile(int id=0)
            
        {
            
            string p = (string)Session["Email"];
            TempData["var"] = p;
            id = c.Logins.Where(x => x.Email == p).Select(y =>
            y.UserID).FirstOrDefault();
            var uservalue = um.GetById(id);
            return View(uservalue);
        }
     
        [HttpPost]
        public ActionResult UserProfile(UserInfo p)
        {
            UserInfoValidatior userInfoValidatior = new UserInfoValidatior();
            ValidationResult results = userInfoValidatior.Validate(p);
            if (results.IsValid)
            {
                um.UserInfoUpdate(p);
                return RedirectToAction("UserProfile");
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





        [HttpGet]
        public ActionResult UserProductExchange(int id=0)

        {
            string p = (string)Session["Email"];
            TempData["var"] = p;
            id = c.Logins.Where(x => x.Email == p).Select(y =>
            y.UserID).FirstOrDefault();
            var uservalue = um.GetById(id);
            

            List<SelectListItem> valueproduct = (from x in pi.GetProductInfoList()
                                                 select new SelectListItem
                                                 {
                                                     Text= x.ProductName,
                                                     Value = x.ProductCarbon.ToString()

                                                 }).ToList();

           
            ViewBag.pi = valueproduct;
            UserInfoAndProductInfoViewModel productInfoViewModel = new UserInfoAndProductInfoViewModel();

            return View(productInfoViewModel);

            
        }

        [HttpPost]
        public ActionResult UserProductExchange(UserInfoAndProductInfoViewModel userInfoProduct)
        {

            string mailinfo = (string)Session["Email"];
            var id = c.Logins.Where(x => x.Email == mailinfo).Select(y =>
            y.UserID).FirstOrDefault();

            var deger = um.GetById(id);

            UserProduct userProduct = new UserProduct();

            userProduct.UserID = id;
            userProduct.ProductBalance= (int)userInfoProduct.ProductInfo.ProductCarbon;
            userProduct.ProductName = userInfoProduct.ProductInfo.ProductName;
            upm.UserProductAdd(userProduct);

            deger.Balance += (int)userInfoProduct.ProductInfo.ProductCarbon;

           

            um.UserInfoUpdate(deger);

            ViewBag.p = id;
            ViewBag.a = id;
            


            UserProductValidatior userproductvalidatior = new UserProductValidatior();
        
            ValidationResult results =userproductvalidatior.Validate(userProduct);
            if (results.IsValid)
            {
               upm.UserProductAdd(userProduct);
                return RedirectToAction("UserProductExchange");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return RedirectToAction("UserProductExchange");

        }




      
























    }
}