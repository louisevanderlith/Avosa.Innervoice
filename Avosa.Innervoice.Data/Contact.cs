namespace Avosa.Innervoice.Data
{
    public class Contact : BaseRecord
    {
        public ContactType ContactType { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }
    }
}
