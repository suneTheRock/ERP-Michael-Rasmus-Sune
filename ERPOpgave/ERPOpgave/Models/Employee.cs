using ERPOpgave.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Models
{
    internal class Employee : Person
    {
        public Employee(Adress adress, ContactInfo contactInfo, string email, string firstName, string lastName, int phone) : base(adress, contactInfo, email, firstName, lastName, phone)
        {
        }

        public int EmplID
        public Employee(Adress adress, ContactInfo contactInfo, string email, string firstName, string lastName, int phone) : base(adress, contactInfo, email, firstName, lastName, phone)
        {
        }

        public int EmplID { get => default; set { } }

        public int Hired { get => default; set { } }

        public int Salary { get => default; set { } }
    }
}
