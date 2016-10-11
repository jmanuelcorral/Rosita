using System;

namespace Rosita.Invoice.Core.Entities
{
    public class NonDetailedInvoice
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public byte InvoiceStatus { get; set; }

        public InvoiceAmounts Costs { get; set; }

    }
}
