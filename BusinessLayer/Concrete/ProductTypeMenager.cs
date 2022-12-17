using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductTypeMenager : IProductTypeService
    {
        IProductTypeDal _productTypeDal;

        public ProductTypeMenager(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }

        public ProductInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductType> GetProductTypeList()
        {
            return _productTypeDal.List();
        }

        public void ProductInfoDelete(ProductType productType)
        {
            throw new NotImplementedException();
        }

        public void ProductInfoUpdate(ProductType productType)
        {
            throw new NotImplementedException();
        }

        public void ProductTypeAdd(ProductType productType)
        {
            throw new NotImplementedException();
        }
    }
}
