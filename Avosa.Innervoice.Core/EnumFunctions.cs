using Avosa.Innervoice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avosa.Innervoice.Core
{
    public static class EnumFunctions
    {
        public static List<KeyValuePair<AddressType, string>> GetAddressTypes()
        {
            var result = new List<KeyValuePair<AddressType, string>>();

            result.Add(AddMember(AddressType.Physical, AddressType.Physical.ToString()));
            result.Add(AddMember(AddressType.Postal, AddressType.Postal.ToString()));

            return result;
        }

        public static List<KeyValuePair<ContactType, string>> GetContactTypes()
        {
            var result = new List<KeyValuePair<ContactType, string>>();

            result.Add(AddMember(ContactType.Cellphone, ContactType.Cellphone.ToString()));
            result.Add(AddMember(ContactType.Telephone, ContactType.Telephone.ToString()));
            result.Add(AddMember(ContactType.Email, ContactType.Email.ToString()));

            return result;
        }

        private static KeyValuePair<T, string> AddMember<T>(T key, string value)
        {
            return new KeyValuePair<T, string>(key, value);
        }
    }
}
