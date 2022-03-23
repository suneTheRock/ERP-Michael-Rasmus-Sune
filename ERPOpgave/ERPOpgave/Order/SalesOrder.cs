using ERPOpgave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Order
{
    internal class SalesOrder
    {
        public enum OrderStatus
        {
            None, Created, Confirmed, Packed, Finished
        }
        internal Models.Customer Customer { get => default; set { } }
        internal List<Orderline> Orderlines;

        internal Orderline Orderline { get => default; set { } }

        public bool Complete { get => default; set { } }

        public DateTime OrderCreated { get => default; set { } }

        public DateTime OrderCompleted { get => default; set { } }

        public string DeliveryAdress { get => default; set { } }

        public int CustomerID { get => default; set { } }

        public int Lines { get => default; set { } }

        public int OrderNumber;

        public SalesOrder(Customer customer, List<Orderline> orderlines, Orderline orderline, bool complete, DateTime created, string deliveryAdress, int iD, int lines, int orderNumber, string orderNames, OrderStatus status)
        {
            Customer = customer;
            Orderlines = orderlines;
            Orderline = orderline;
            Complete = complete;
            OrderCreated = created;
            DeliveryAdress = deliveryAdress;
            CustomerID = iD;
            Lines = lines;
            OrderNumber = orderNumber;
            OrderNames = orderNames;
            Status = status;
        }

        public string OrderNames { get => default; set { } }

        public OrderStatus Status { get; }

        public decimal OrderAmount { get => GetOrderAmount(); set { } }

        public decimal GetOrderAmount() 
        {
            decimal returnamount = 0;
            foreach (var orderline in Orderlines)
            {
                returnamount += (Orderline.UnitPrice * Orderline.Quantity);
            }
            return returnamount;
        }
    }
}
