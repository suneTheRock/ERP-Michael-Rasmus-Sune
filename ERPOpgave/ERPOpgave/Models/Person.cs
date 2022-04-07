using ERPOpgave.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Models
{
    public class Person
    {
        public Person(string email, string firstName, string lastName, int phone)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.FullName = $"{firstName} {lastName}";
            this.LastName = lastName;
            this.Phone = phone;
        }
        public Person(Adress adress, ContactInfo contactInfo, string email, string firstName, string lastName, int phone)
        {
            this.Adress = adress;
            this.ContactInfo = contactInfo;
            this.Email = email;
            this.FirstName = firstName;
            this.FullName = $"{firstName} {lastName}";
            this.LastName = lastName;
            this.Phone = phone;
        }

        public Person()
        {

        }

        internal PersonalInfo.Adress Adress { get; set; }

        internal PersonalInfo.ContactInfo ContactInfo { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string FullName { get; set; }

        public string LastName { get; set; }

        public int Phone { get; set; }
    }
}
