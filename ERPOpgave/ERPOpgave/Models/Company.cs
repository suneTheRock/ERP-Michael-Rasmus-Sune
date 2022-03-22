using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Models
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }

    }
}
