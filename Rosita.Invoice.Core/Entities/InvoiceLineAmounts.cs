namespace Rosita.Invoice.Core.Entities
{
    public class InvoiceLineAmounts
    {
        public decimal? Tax { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? UnitPriceWithTax { get; set; }

        public decimal? TotalLineWithTax { get; set; }
    }
}