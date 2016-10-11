using System;
using System.Collections.Generic;

namespace Rosita.Infrastructure.Database.Entities
{
    public class Invoice:BaseDao<Guid>
    {
        
        public string Code { get; set; }

        public Guid ClientId { get; set; }

        public byte InvoiceStatus { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Tax { get; set; }

        public decimal? AmountWithTax { get; set; }

        public virtual Customer Client { get; set; }

        public virtual ICollection<InvoiceLine>  InvoiceLines { get; set; }

        public virtual ICollection<InvoiceRecord> InvoiceRecords { get; set; }
    }
}