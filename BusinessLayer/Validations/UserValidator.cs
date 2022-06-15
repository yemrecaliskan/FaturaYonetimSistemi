using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {            
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Adınızı giriniz");
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2).WithMessage("Soyadınızı giriniz");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5).WithMessage("şifreniz en az 5 harf olmalıdır");
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(10).MaximumLength(13).WithMessage("Telefon numaranızı doğru giriniz");
            RuleFor(x => x.TCNo).NotEmpty().MinimumLength(11).MaximumLength(11).WithMessage("TC numaranızı doğru giriniz");            
        }
    }
}
