using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class House
    {
        [Key]
        public int HouseID { get; set; }
        public int Block { get; set; }
        public bool IsEmpty { get; set; }
        public string Type { get; set; }
        public int Layer { get; set; }
        public int HouseNumber { get; set; }
        public int Subscription { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
    }
}
