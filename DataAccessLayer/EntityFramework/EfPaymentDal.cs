using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPaymentDal : GenericRepository<Payment> , IPaymentDal
    {
        public List<Payment> GetPaymentListWithHouse()
        {
            using (var c = new Context())
            {
                return c.Payments.Include(x => x.House).ToList();
            }
        }

        public List<Payment> GetPaymentListWithHouse(int id)
        {
            using (var c = new Context())
            {
                return c.Payments.Include(x => x.House).Where(x => x.House.UserID == id && x.IsPaid == false).ToList();
            }
        }

        public Payment GetPaymentWithHouse(int id)
        {
            using (var c = new Context())
            {
                return c.Payments.Include(x => x.House).Where(x => x.PaymentID == id && x.IsPaid == false).FirstOrDefault();
            }
        }
    }
}
