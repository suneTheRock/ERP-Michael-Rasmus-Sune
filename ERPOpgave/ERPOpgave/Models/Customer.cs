using ERPOpgave.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Models
{
    public class Customer : Person
    {
        public Customer(Adress adress, ContactInfo contactInfo, string email, string firstName, string lastName, int phone) : base(adress, contactInfo, email, firstName, lastName, phone)
        {
        }
        public Customer(int customerid, string email, string firstName, string lastName, int phone) :base(email, firstName, lastName,phone)
        {
            CustomerID = customerid;
            Email = email;
            FullName = $"{firstName} {lastName}";
            Phone = phone;

        }
        public int CustomerID { get => default; set { } }
        public int CustomerNumber { get => default; set { } }
        public int LastOrderDate { get => default; set { } }
    }
}
