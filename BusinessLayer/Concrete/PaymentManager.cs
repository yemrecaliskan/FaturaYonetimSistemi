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
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public Payment GetByID(int id)
        {
            return _paymentDal.GetByID(id);
        }

        public List<Payment> GetList()
        {
            return _paymentDal.GetListAll();
        }

        public List<Payment> GetPaymentListWithHouse()
        {
            return _paymentDal.GetPaymentListWithHouse();
        }

        public List<Payment> GetPaymentListWithHouse(int id)
        {
            return _paymentDal.GetPaymentListWithHouse(id);
        }

        public Payment GetPaymentWithHouse(int id)
        {
            return _paymentDal.GetPaymentWithHouse(id);
        }

        public void TAdd(Payment t)
        {
            _paymentDal.Insert(t);
        }

        public void TDelete(Payment t)
        {
            _paymentDal.Delete(t);
        }

        public void TUpdate(Payment t)
        {
            _paymentDal.Update(t);
        }
    }
}
