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
            this.CustomerID = customerid;
            this.Email = email;
            this.FullName = $"{firstName} {lastName}";
            this.Phone = phone;

        }
        public int CustomerID { get; set; }
        public int CustomerNumber { get; set; }
        public DateTime LastOrder { get; set; }
    }
}
