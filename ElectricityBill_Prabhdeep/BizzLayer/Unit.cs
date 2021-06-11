using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricityBill_Prabhdeep.BizzLayer
{
    public class Unit
    {
        public int ID { get; set; }
        public int TotalUnits { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
