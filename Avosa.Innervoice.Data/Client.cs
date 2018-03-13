using System.Collections.Generic;

namespace Avosa.Innervoice.Data
{
    public class Client : BaseRecord
    {
        public Client()
        {
            ContactDetails = new List<Contact>();
        }

        public string Name { get; set; }

        public Address Address { get; set; }

        public List<Contact> ContactDetails { get; set; }
    }
}
