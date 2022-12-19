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

namespace RecycleCoinProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        ProductInfoMenager pi = new ProductInfoMenager(new EfProductInfoDal());
       ProductTypeMenager pt = new ProductTypeMenager(new EfProductTypeDal());
        
        public ActionResult Index()
        {
            var productinfovalues = pi.GetProductInfoList();
            return View(productinfovalues);


        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> valueproduct = (from x in pt.GetProductTypeList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.ProductName,
                                                      Value=x.ProductTypeID.ToString()

                                                  }).ToList();
            ViewBag.pi = valueproduct; 
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductInfo p)
        {
            ProductInfoValidatior userInfoValidatior = new ProductInfoValidatior();
            ValidationResult results = userInfoValidatior.Validate(p);
            if (results.IsValid)
            {
                pi.ProductInfoAdd(p);
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
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            List<SelectListItem> valueproduct = (from x in pt.GetProductTypeList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ProductName,
                                                     Value = x.ProductTypeID.ToString()

                                                 }).ToList();
            ViewBag.pi = valueproduct;

            var ProductValue = pi.GetById(id);
            return View(ProductValue);
        }
        [HttpPost]
        public ActionResult EditProduct(ProductInfo p)
        {
            pi.ProductInfoUpdate(p);
            return RedirectToAction("Index");

        }
    }
}