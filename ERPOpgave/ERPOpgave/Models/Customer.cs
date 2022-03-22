using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Models
{
    internal class Customer : Person
    {
        public int CustomerNumber
        {
            get => default;
            set
            {
            }
        }

        public int LastOrderDate
        {
            get => default;
            set
            {
            }
        }
    }
}
