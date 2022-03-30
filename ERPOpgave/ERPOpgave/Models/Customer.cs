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
        public Adress adress = new();
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

        public Customer(int customerId, string firstname, string lastName, string email, int phone, string adress, int adressNr, int postNummer, string city) :base(email, firstname, lastName, phone)
        {
            this.CustomerID=customerId;
            this.adress.Street = adress;
            this.adress.City = city;
            this.adress.Number = adressNr;
            this.adress.ZipCode = postNummer;
            this.Phone = phone;
        }
        public int CustomerID { get; set; }
        public int CustomerNumber { get; set; }
        public DateTime LastOrder { get; set; }
    }
}
