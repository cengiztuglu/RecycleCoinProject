using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class LoginValidatior: AbstractValidator<Login>
    {
        public LoginValidatior()
        {
            {
                RuleFor(x => x.Email).NotEmpty().WithMessage("Adı Boş Geçemezsiniz");
                RuleFor(x=>x.Password).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz ");
            }
        }

    }
}
