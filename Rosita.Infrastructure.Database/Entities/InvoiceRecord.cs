using System;

namespace Rosita.Infrastructure.Database.Entities
{
    public class InvoiceRecord:BaseDao<Guid>
    {
        public Guid InvoiceId { get; set; }

        public DateTime Recorded { get; set; }

        public string WhoHasModified { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}