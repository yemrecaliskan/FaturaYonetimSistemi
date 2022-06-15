using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPaymentService : IGenericService<Payment>
    {
        List<Payment> GetPaymentListWithHouse();
        List<Payment> GetPaymentListWithHouse(int id);
        Payment GetPaymentWithHouse(int id);
    }
}
