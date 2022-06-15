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
    public class AdminUserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());
        public IActionResult Index()
        {
            var users = userManager.GetList();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User u)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult result = userValidator.Validate(u);
            if (result.IsValid)
            {
                u.IsActive = true;
                userManager.TAdd(u);
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
        public IActionResult UpdateUser(int id)
        {
            var user = userManager.GetByID(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult UpdateUser(User u)
        {
            UserValidator validator = new UserValidator();
            var user = userManager.GetList().Where(x => x.UserID == u.UserID).SingleOrDefault();
            u.Password = user.Password;
            u.TCNo = user.TCNo;
            u.PhoneNumber = user.PhoneNumber;
            ValidationResult result = validator.Validate(u);
            if (result.IsValid)
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
                return View();
            }
        }
        public IActionResult DeleteUser(int id)
        {
            var user = userManager.GetByID(id);
            userManager.TDelete(user);
            return RedirectToAction("Index");
        }
    }
}
