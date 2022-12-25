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

namespace RecycleCoinProject.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: User

        UserMenager um = new UserMenager(new EfUserInfoDal());
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
        public ActionResult UserProductExchange(int id = 0)

        {


         

            string p = (string)Session["Email"];
            id = c.Logins.Where(x => x.Email == p).Select(y =>
            y.UserID).FirstOrDefault();

            var uservalue = upm.GetById(id);


          
          
            List<SelectListItem> valueproduct = (from x in pi.GetProductInfoList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ProductName,
                                                     Value = x.ProductID.ToString()

                                                 }).ToList();
            ViewBag.pi = valueproduct;
           

            return View(uservalue);
        }

        [HttpPost]
        public ActionResult UserProductExchange(UserProduct p)
        {

         





            UserProductValidatior userproductvalidatior = new UserProductValidatior();
        
            ValidationResult results =userproductvalidatior.Validate(p);
            if (results.IsValid)
            {
               upm.UserProductAdd(p);
                return RedirectToAction("UserProductExchange");
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