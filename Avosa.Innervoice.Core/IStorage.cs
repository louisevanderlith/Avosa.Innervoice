using Avosa.Innervoice.Data;
using Lith.DocStore;

namespace Avosa.Innervoice.Core
{
    public interface IStorage
    {
        ItemSet<Address> Addresses { get; set; }

        ItemSet<Client> Clients { get; set; }

        ItemSet<LineItem> LineItems { get; set; }

        ItemSet<Profile> Profiles { get; set; }

        ItemSet<Quote> Quotes { get; set; }

        ItemSet<SubItem> SubItems { get; set; }

        void Save();
    }
}
