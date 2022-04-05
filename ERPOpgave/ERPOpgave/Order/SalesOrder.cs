using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Order
{
    public class SalesOrder
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> origin/Customer
    }
}
