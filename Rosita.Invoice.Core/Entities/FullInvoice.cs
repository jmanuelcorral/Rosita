using System;
using System.Collections.Generic;

namespace Rosita.Invoice.Core.Entities
{
    public class FullInvoice
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public byte InvoiceStatus { get; set; }

        public InvoiceAmounts Costs { get; set; }

        public Customer Customer { get; set; }

        public virtual IEnumerable<InvoiceLine> InvoiceLines { get; set; }

    }
}