using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Office // sucursal.
    {
        public Office(string address, string idCode, string responsableName, int contactNumber, string emailAddress)
        {
            Address = address;
            IdCode = idCode;
            ResponsableName = responsableName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public string Address { get; set; }
        public string IdCode { get; set; }
        public string ResponsableName { get; set; }
        public int ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
