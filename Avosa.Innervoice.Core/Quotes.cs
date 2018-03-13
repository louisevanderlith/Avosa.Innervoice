using Avosa.Innervoice.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avosa.Innervoice.Core
{
    public class Quotes
    {
        private readonly IStorage _context;

        public Quotes(IStorage context)
        {
            _context = context;
        }

        public Confirmer Create(Quote quote)
        {
            var result = new Confirmer();

            try
            {
                quote.Status = Status.Created;

                _context.Quotes.Add(quote);
                _context.Save();
            }
            catch (Exception exc)
            {
                result.SetError(exc.ToString());
            }

            return result;
        }

        public IList<Quote> GetOverdue()
        {
            var result = new List<Quote>();

            var overdue = from q in _context.Quotes
                          where !q.IsDeleted
                          && (q.DueDate > DateTime.Now || q.Status == Status.Overdue)
                          select q;

            foreach (var item in overdue.Where(a => a.Status != Status.Overdue))
            {
                ChangeStatus(item.ID, Status.Overdue);
            }

            return result;
        }

        public Confirmer Accept(Guid quoteID)
        {
            return ChangeStatus(quoteID, Status.Accepted);
        }

        public Confirmer Reject(Guid quoteID)
        {
            return ChangeStatus(quoteID, Status.Rejected);
        }

        public Confirmer Cancel(Guid quoteID)
        {
            return ChangeStatus(quoteID, Status.Cancelled);
        }

        private Confirmer ChangeStatus(Guid quoteID, Status status)
        {
            var result = new Confirmer();

            try
            {
                var quote = _context.Quotes.Find(quoteID);
                quote.Status = status;

                if (status == Status.Accepted)
                {
                    quote.IsInvoice = true;
                }

                _context.Save();
            }
            catch (Exception exc)
            {
                result.SetError(exc.ToString());
            }

            return result;

        }
    }
}
