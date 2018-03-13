using System;
using System.Collections.Generic;

namespace Avosa.Innervoice.Data
{
    public class Profile : BaseRecord
    {
        public Profile()
        {
            ContactDetails = new List<Contact>();
        }

        public string Name { get; set; }

        public string RegistrationNo { get; set; }

        public Address Address { get; set; }

        public List<Contact> ContactDetails { get; set; }

        public Guid LogoID { get; set; }
    }
}
