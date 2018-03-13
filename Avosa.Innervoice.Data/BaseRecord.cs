using Lith.DocStore.Interfaces;
using System;

namespace Avosa.Innervoice.Data
{
    public abstract class BaseRecord : IStoreable
    {
        public Guid ID { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
