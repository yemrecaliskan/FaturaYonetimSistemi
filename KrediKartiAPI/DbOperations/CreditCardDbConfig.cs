using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrediKartiAPI.DbOperations
{
    public class CreditCardDbConfig
    {
        public string Database_Name { get; set; }
        public string CreditCards_Collection_Name { get; set; }
        public string Connection_String { get; set; }
    }
}
