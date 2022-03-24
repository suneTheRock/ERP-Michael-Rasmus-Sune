using ERPOpgave.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Models
{
    internal class Customer : Person
    {
        public Customer(Adress adress, ContactInfo contactInfo, string email, string firstName, string lastName, int phone) : base(adress, contactInfo, email, firstName, lastName, phone)
        {
        }

        public int CustomerNumber { get => default; set { } }

        public int LastOrderDate { get => default; set { } }
    }
}
