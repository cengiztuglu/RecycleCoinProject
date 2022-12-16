using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public class UserInfoValidatior:AbstractValidator<UserInfo>
    {
        public UserInfoValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adı Boş Geçemezsiniz");
            RuleFor(x => x.PhoneNumber).MinimumLength(11).WithMessage("Lütfen 11 Karakterden Fazla Girmeyiniz");
        }

    }
}
