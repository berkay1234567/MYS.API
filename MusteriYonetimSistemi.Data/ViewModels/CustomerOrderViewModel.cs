using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriYonetimSistemi.Data.ViewModels
{
    public class CustomerOrderViewModel
    {
        public int OrderID { get; set; }
        public string UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }

        public string CustomerSurName { get; set; }
    }
}
