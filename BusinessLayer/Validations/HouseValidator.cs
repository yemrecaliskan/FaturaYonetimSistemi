using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class HouseValidator : AbstractValidator<House>
    {
        public HouseValidator()
        {
            RuleFor(x => x.Layer).NotEmpty().WithMessage("Kat bilgisi boş bırakılamaz.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Ev tipi boş bırakılamaz.");
            RuleFor(x => x.HouseNumber).NotEmpty().WithMessage("Ev numarası boş bırakılamaz.").GreaterThan(0).WithMessage("Ev numarası 0'dan büyük olmalı");
            RuleFor(x => x.Block).NotEmpty().WithMessage("Blok numarası boş bırakılamaz.").GreaterThan(0).WithMessage("Blok numarası 0'dan büyük olmalı");            
        }
    }
}
