using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.PersonalInfo
{
    public class ContactInfo
    {
        public int ContactInfoID { get; set; }

        public int Value { get; set; }

        public ContactInfo(int value)
        {
            this.Value = value;  
        }
    }

    
}
