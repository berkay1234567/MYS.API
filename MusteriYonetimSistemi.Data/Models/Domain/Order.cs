using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriYonetimSistemi.Data.Models.Domain
{
    public class Order
    {
        public int OrderID { get; set; }  
        public string UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
