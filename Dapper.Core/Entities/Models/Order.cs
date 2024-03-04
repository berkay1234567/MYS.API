using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
