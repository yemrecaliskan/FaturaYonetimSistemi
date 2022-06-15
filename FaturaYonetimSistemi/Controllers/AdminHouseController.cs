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
    public class AdminHouseController : Controller
    {
        HouseManager houseManager = new HouseManager(new EfHouseDal()); 

        public IActionResult Index()
        {
            var values = houseManager.GetList();
            return View(values);
        }

        public IActionResult GetHouseDetail(int id)
        {
            var value = houseManager.GetByID(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult AddHouse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHouse(House h)
        {
            HouseValidator validator = new HouseValidator();
            ValidationResult result = validator.Validate(h);
            if (result.IsValid)
            {
                h.IsEmpty = false;
                houseManager.TAdd(h);
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

        [HttpGet]
        public IActionResult UpdateHouse(int id)
        {
            var house = houseManager.GetByID(id);
            return View(house);
        }

        [HttpPost]
        public IActionResult UpdateHouse(House h)
        {
            var x = houseManager.GetList().Where(x => x.HouseID == h.HouseID).SingleOrDefault();
            x.HouseNumber = h.HouseNumber;
            x.Layer = h.Layer;
            x.Type = h.Type;
            x.Block = h.Block;
            houseManager.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteHouse(int id)
        {
            var house = houseManager.GetByID(id);
            houseManager.TDelete(house);
            return RedirectToAction("Index");
        }
    }
}
