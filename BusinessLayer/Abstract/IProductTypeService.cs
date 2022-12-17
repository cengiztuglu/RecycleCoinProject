using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductTypeService
    {
        List<ProductType> GetProductTypeList();
        void ProductTypeAdd(ProductType productType);
        ProductInfo GetById(int id);

        void ProductInfoDelete(ProductType productType);
        void ProductInfoUpdate(ProductType productType);
    }
}
