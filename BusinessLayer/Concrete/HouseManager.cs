using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HouseManager : IHouseService
    {
        IHouseDal _houseDal;

        public HouseManager(IHouseDal houseDal)
        {
            _houseDal = houseDal;
        }

        public House GetByID(int id)
        {
            return _houseDal.GetByID(id);
        }

        public List<House> GetList()
        {
            return _houseDal.GetListAll();
        }

        public List<House> GetLoggedUserHouse(int id)
        {
            return _houseDal.GetLoggedUserHouse(id);
        }

        public void TAdd(House t)
        {
            _houseDal.Insert(t);
        }

        public void TDelete(House t)
        {
            _houseDal.Delete(t);
        }

        public void TUpdate(House t)
        {
            _houseDal.Update(t);
        }
    }
}
