using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static FaturaYonetimSistemi.ViewComponents.Payment.GetPayment;

namespace FaturaYonetimSistemi.Controllers
{
    public class KrediKartiAPIController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());
        PaymentManager paymentManager = new PaymentManager(new EfPaymentDal());

        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CardClass cc)
        {
            var usermail = User.Identity.Name;
            var uservalue = userManager.getLoggedUser(usermail);
            int idUser = uservalue.UserID;
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44368/CreditCards/" + idUser);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<CardClass>(jsonString);

            var sum = Value.sum;
            int id = Value.paymentID;

            if (cc.CardNumber == values.CardNumber && decimal.Parse(values.Balance.ToString()) >= sum && cc.ExpireDate == values.ExpireDate && cc.CVC == values.CVC)
            {
                values.Balance = values.Balance - sum;
                var pay = paymentManager.GetPaymentWithHouse(id);
                pay.BillSum = 0;
                pay.IsPaid = true;
                paymentManager.TUpdate(pay);


                var jsonCard = JsonConvert.SerializeObject(values);
                var content = new StringContent(jsonCard, Encoding.UTF8, "application/json");
                var responseMessage2 = await httpClient.PutAsync("https://localhost:44368/CreditCards/", content);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }

    public class CardClass
    {
        public string CardID { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string ExpireDate { get; set; }
        public int UserID { get; set; }
        public decimal Balance { get; set; }
    }
}
