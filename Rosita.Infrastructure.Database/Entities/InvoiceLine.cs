using System;

namespace Rosita.Infrastructure.Database.Entities
{
    public class InvoiceLine: BaseDao<Guid>
    {
        public Guid InvoiceId { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal? Tax { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? UnitPriceWithTax { get; set; }

        public decimal? TotalLineWithTax { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}