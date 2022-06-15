using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public decimal BillSum { get; set; }
        public DateTime BillDate { get; set; }
        public bool IsPaid { get; set; }

        public int HouseID { get; set; }
        public House House { get; set; }
    }
}
