namespace Rosita.Invoice.Core.Entities
{
    public class InvoiceAmounts
    {
        public decimal Amount { get; set; }

        public decimal Tax { get; set; }

        public decimal AmountWithTax { get; set; }
    }
}