using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminID).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Email).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5);            
        }
    }
}
