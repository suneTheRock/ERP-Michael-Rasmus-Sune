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
<<<<<<< HEAD
        public Customer(Adress adress, ContactInfo contactInfo, string email, string firstName, string lastName, int phone, int customerNumber) : base(adress, contactInfo, email, firstName, lastName, phone)
=======
        
        public Customer(Adress adress, ContactInfo contactInfo, string email, string firstName, string lastName, int phone) : base(adress, contactInfo, email, firstName, lastName, phone)
>>>>>>> origin/Customer
        {
            CustomerNumber = customerNumber;
        }
        public Customer(int customerid, string email, string firstName, string lastName, int phone) :base(email, firstName, lastName,phone)
        {
            this.CustomerID = customerid;
            this.Email = email;
            this.FullName = $"{firstName} {lastName}";
            this.Phone = phone;

<<<<<<< HEAD
        public int CustomerNumber { get; set; }
=======
        }
>>>>>>> origin/Customer

        public Customer(int customerId, string firstname, string lastName, string email, int phone, Adress adress) :base(email, firstname, lastName, phone)
        {
            this.CustomerID=customerId;
            this.Adress = adress;
            this.Phone = phone;
        }
        public int CustomerID { get; set; }
        public int CustomerNumber { get; set; }
        public DateTime LastOrder { get; set; }
    }
}
