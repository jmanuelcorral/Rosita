using System;

namespace Rosita.Invoice.Core.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }

        public string LegalDocument { get; set; }

        public bool? CanAvoidTax { get; set; }

        public string email { get; set; }

        public InvoiceAddress MainAddress { get; set; }
    }
}