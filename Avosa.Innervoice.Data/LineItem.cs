using System.Collections.Generic;

namespace Avosa.Innervoice.Data
{
    public class LineItem : BaseRecord
    {
        public LineItem()
        {
            Items = new List<SubItem>();
        }

        public string Description { get; set; }

        public decimal UnitCost { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost
        {
            get
            {
                return Quantity * UnitCost;
            }
        }

        public List<SubItem> Items { get; set; }
    }
}
