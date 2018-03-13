using System;
using System.Collections.Generic;

namespace Avosa.Innervoice.Data
{
    public class Quote : BaseRecord
    {
        public Quote()
        {
            IsInvoice = false;
            LineItems = new List<LineItem>();
        }

        public Status Status { get; set; }

        public bool IsInvoice { get; set; }

        public DateTime DueDate { get; set; }

        public string Number
        {
            get
            {
                var result = !IsInvoice ? "Q" : string.Empty;

                result += GenerateNumber();

                return result;
            }
        }

        private string GenerateNumber()
        {
            var parts = ID.ToString().Split('-');

            return parts[1] + parts[3];
        }

        public List<LineItem> LineItems { get; set; }
    }
}
