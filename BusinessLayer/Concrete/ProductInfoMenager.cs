using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using BusinessLayer.Abstact;
using BusinessLayer.Concrete;

namespace BusinessLayer.Concrete
{

    public class ProductInfoMenager : IProductInfoService
    {
        IProductInfoDal _productInfoDal;

        public ProductInfoMenager(IProductInfoDal productInfoDal)
        {
            _productInfoDal = productInfoDal;
        }

        public ProductInfo GetById(int id)
        {
            return _productInfoDal.Get(x => x.ProductID == id);
        }

        public List<ProductInfo> GetProductInfoList()
        {
            return _productInfoDal.List();
        }

        public void ProductInfoAdd(ProductInfo productInfo)
        {
            _productInfoDal.Insert(productInfo);
        }

        public void ProductInfoDelete(ProductInfo productInfo)
        {
            _productInfoDal.Delete(productInfo);
        }

        public void ProductInfoUpdate(ProductInfo productInfo)
        {
            _productInfoDal.Update(productInfo);
        }
    }
}
