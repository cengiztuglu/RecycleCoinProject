using System;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstact
{
    public interface IProductInfoService
    {
        List<ProductInfo> GetProductInfoList();
        void ProductInfoAdd(ProductInfo productInfo);
        ProductInfo GetById(int id);

        void ProductInfoDelete(ProductInfo productInfo);
        void ProductInfoUpdate(ProductInfo productInfo);
    }
}
