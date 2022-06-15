using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.ViewComponents.House
{
    public class GetUserHouse:ViewComponent
    {
        UserManager userManager = new UserManager(new EfUserDal()); 
        HouseManager houseManager = new HouseManager(new EfHouseDal());
        public IViewComponentResult Invoke(int id)
        {
            var usermail = User.Identity.Name;
            var value = userManager.GetList().Where(x => x.Email == usermail);
            if(value is null)
            {
                id = 1;
            }
            else
            {
                var writervalue = userManager.getLoggedUser(usermail);
                id = writervalue.UserID;
            }            
            
            var values = houseManager.GetLoggedUserHouse(id);

            return View(values);
        }
    }
}
