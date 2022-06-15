using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.ViewComponents.House
{
    public class CreditCardHouseInfo:ViewComponent
    {
        PaymentManager paymentManager = new PaymentManager(new EfPaymentDal());

        public IViewComponentResult Invoke(int id)
        {
            var values = paymentManager.GetPaymentListWithHouse(id);

            return View(values);
        }
    }
}
