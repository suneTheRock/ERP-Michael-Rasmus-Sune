using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Order
{
    internal class Orderline
    {
        public int ItemNumber { get; set; }

        public string ItemText { get; set; }

        public int Property { get; set; }

        public int Quantity { get; set; }

        public decimal Units { get; set; }

        public decimal UnitPrice { get; set; }
        public Products.Product Product { get; set; }

        public decimal Total { get { return Quantity * UnitPrice; } }
    }
}
