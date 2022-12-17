using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductInfoValidatior:AbstractValidator<ProductInfo>
    {
        public ProductInfoValidatior()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Adı Boş Geçemezsiniz");
            RuleFor(x => x.ProductTypeID).NotEmpty().WithMessage("ID Boş Geçemezsiniz");
            RuleFor(x => x.ProductCarbon).NotEmpty().WithMessage("ID Boş Geçemezsiniz");


        }
  

    }
}
