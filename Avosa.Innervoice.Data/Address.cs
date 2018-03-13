namespace Avosa.Innervoice.Data
{
    public class Address : BaseRecord
    {
        public string StreetNo { get; set; }

        public string Street { get; set; }

        public string UnitNo { get; set; }

        public string EstateName { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Coordinates { get; set; }

        public AddressType Type { get; set; }
    }
}
