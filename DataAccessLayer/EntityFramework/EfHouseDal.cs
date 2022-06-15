using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfHouseDal : GenericRepository<House>, IHouseDal
    {
        public List<House> GetLoggedUserHouse(int id)
        {
            using (var c = new Context())
            {
                return c.Houses.Where(x => x.UserID == id).ToList();
            }
        }
    }
}
