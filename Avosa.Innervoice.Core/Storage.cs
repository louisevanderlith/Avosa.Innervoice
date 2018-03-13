using Avosa.Innervoice.Data;
using Lith.DocStore;
using Lith.DocStore.ModelHelper;

namespace Avosa.Innervoice.Core
{
    public class Storage : StoreContext, IStorage
    {
        public Storage()
            : base(new JSONModelHelper())
        { }

        public ItemSet<Address> Addresses { get; set; }

        public ItemSet<Client> Clients { get; set; }

        public ItemSet<LineItem> LineItems { get; set; }

        public ItemSet<Profile> Profiles { get; set; }

        public ItemSet<Quote> Quotes { get; set; }

        public ItemSet<SubItem> SubItems { get; set; }
    }
}
