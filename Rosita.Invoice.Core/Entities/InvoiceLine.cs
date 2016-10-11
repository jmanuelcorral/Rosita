using System;

namespace Rosita.Invoice.Core.Entities
{
    public class InvoiceLine
    {
        public string InvoiceCode { get; set; }

        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public InvoiceLineAmounts Amounts { get; set; }

    }
}