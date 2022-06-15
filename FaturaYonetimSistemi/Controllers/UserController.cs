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
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());

        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            var uservalue = userManager.getLoggedUser(usermail);
            ViewBag.d = uservalue.UserID;
            return View(uservalue);
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = userManager.GetByID(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(User u)
        {
            UserValidator userValidator = new UserValidator();
            var user = userManager.GetList().Where(x => x.UserID == u.UserID).SingleOrDefault();
            u.TCNo = user.TCNo;
            ValidationResult result = userValidator.Validate(u);
            string confirmPassword = Request.Form["confirmPassword"];
            if (result.IsValid && u.Password == confirmPassword)
            {
                userManager.TUpdate(u);
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
    }
}
