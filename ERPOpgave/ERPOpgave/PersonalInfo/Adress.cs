using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.PersonalInfo
{
    public class Adress
    {
        public Adress(string city, int number, string street, int zipCode)
        {
            City = city;
            Number = number;
            Street = street;
            ZipCode = zipCode;
        }
        public Adress()
        {

        }

        public string City { get; set;  }

        public int Number { get; set; }

        public string Street { get; set; }

        public int ZipCode { get; set; }

        public void ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
