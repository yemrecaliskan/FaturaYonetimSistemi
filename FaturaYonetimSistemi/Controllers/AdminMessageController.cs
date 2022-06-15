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
    public class AdminMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [HttpGet]
        public IActionResult Inbox()
        {
            var adminMail = User.Identity.Name;
            var messagelist = messageManager.GetListInbox(adminMail);
            var count = messageManager.GetListInbox(adminMail).Where(x => x.MessageStatus == false).Count();
            TempData["count"] = count;

            return View(messagelist);
        }

        [HttpGet]
        public IActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            values.MessageStatus = true;
            messageManager.TUpdate(values);
            return View(values);
        }

        [HttpGet]
        public IActionResult Sendbox()
        {
            var adminMail = User.Identity.Name;
            var messagelist = messageManager.GetListSendbox(adminMail);
            return View(messagelist);
        }

        [HttpGet]
        public IActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message m)
        {
            var adminMail = User.Identity.Name;
            m.SenderMail = adminMail;
            ValidationResult result = messageValidator.Validate(m);
            if (result.IsValid)
            {
                m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.TAdd(m);
                return RedirectToAction("Sendbox");
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
    }
}
