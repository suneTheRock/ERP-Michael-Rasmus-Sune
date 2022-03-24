using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Order
{
    internal class SalesOrder
    {
        public enum Complete
        {
            Yes,
            No
        }
        internal Models.Customer Customer { get => default; set { } }

        internal List<Orderline> Orderlines;
        internal Orderline Orderline { get => default; set { } }
        public Complete Completed { get => default; set { } }
        public DateTime Created { get => default; set { } }
        public string DeliveryAdress { get => default; set { } }
        public int ID { get => default; set { } }
        public int Lines { get => default; set { } }
        public int OrderNumber;
        public string OrderNames { get => default; set { } }
    }
}
