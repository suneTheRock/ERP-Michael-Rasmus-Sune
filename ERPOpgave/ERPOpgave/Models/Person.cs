using ERPOpgave.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Models
{
    internal class Person
    {
        public Person(Adress adress, ContactInfo contactInfo, string email, string firstName, string lastName, int phone)
        {
            Adress = adress;
            ContactInfo = contactInfo;
            Email = email;
            FirstName = firstName;
            FullName = $"{firstName} {lastName}";
            LastName = lastName;
            Phone = phone;
        }

        internal PersonalInfo.Adress Adress { get => default; set { } }

        internal PersonalInfo.ContactInfo ContactInfo { get => default; set { } }

        public string Email { get => default; set { } }

        public string FirstName { get => default; set { } }

        public string FullName { get => default; set { } }

        public string LastName { get => default; set { } }

        public int Phone { get => default; set { } }
    }
}
