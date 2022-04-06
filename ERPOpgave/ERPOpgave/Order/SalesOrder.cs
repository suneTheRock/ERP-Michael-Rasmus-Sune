using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Order
{
    public class SalesOrder
    {
        public SalesOrder(int orderID, DateTime date)
        {
            OrderNumber = orderID;
            Created = date;
            //TODO:
            //CustomerID, CustomerName, Order Amount
            
        }
        internal Models.Customer Customer { get; set; }

        internal List<Orderline> Lines { get; set; }

        internal Orderline Orderline { get; set; }       
        public DateTime Complete { get; set; }

        public DateTime Created { get; set; }

        public string DeliveryAdress { get; set; }
        public int ID { get; set; } // TODO: Skal den her være her??????

        public int OrderNumber { get; set; }
        public int OrderNames { get; set; }

        public string FullName { get { return Customer.FullName; } }
        public int CustomerID { get { return Customer.CustomerNumber; } }

        public decimal Amount { get { return GetAmount(); } }

        public decimal GetAmount()
        {
            decimal fullamount =0;
            for (int i=0; i < Lines.Count; i++)
            {
                fullamount =+ Orderline.Total;
            }
            return fullamount;
            
        }
    }
}
