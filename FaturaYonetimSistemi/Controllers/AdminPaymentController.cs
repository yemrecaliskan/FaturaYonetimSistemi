using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Controllers
{
    public class AdminPaymentController : Controller
    {
        PaymentManager paymentManager = new PaymentManager(new EfPaymentDal());
        PaymentValidator paymentValidator = new PaymentValidator();

        [HttpGet]
        public IActionResult Index()
        {
            var payments = paymentManager.GetPaymentListWithHouse();
            return View(payments);
        }

        [HttpGet]
        public IActionResult AddPayment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPayment(Payment p)
        {
            ValidationResult result = paymentValidator.Validate(p);
            if (result.IsValid)
            {
                p.BillDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                paymentManager.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult EditPayment(int id)
        {
            var paymentValue = paymentManager.GetByID(id);
            return View(paymentValue);
        }

        [HttpPost]
        public IActionResult EditPayment(Payment p)
        {
            ValidationResult result = paymentValidator.Validate(p);
            if (result.IsValid)
            {
                paymentManager.TUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeletePayment(int id)
        {
            var payment = paymentManager.GetByID(id);
            paymentManager.TDelete(payment);
            return RedirectToAction("Index");
        }
    }
}
