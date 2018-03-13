namespace Avosa.Innervoice.Data
{
    public class Contact : BaseRecord
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }
    }
}
