using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Order
{
    internal class SalesOrder
    {

        internal Models.Customer Customer
        {
            get => default;
            set
            {
            }
        }
        internal List<Orderline> Orderlines;

        internal Orderline Orderline
        {
            get => default;
            set
            {
            }
        }

        public int Complete
        {
            get => default;
            set
            {
            }
        }

        public int Created
        {
            get => default;
            set
            {
            }
        }

        public int DeliveryAdress
        {
            get => default;
            set
            {
            }
        }

        public int ID
        {
            get => default;
            set
            {
            }
        }

        public int Lines
        {
            get => default;
            set
            {
            }
        }
        public int OrderNumber;
        public int OrderNames
        {
            get => default;
            set
            {
            }
        }
    }
}
