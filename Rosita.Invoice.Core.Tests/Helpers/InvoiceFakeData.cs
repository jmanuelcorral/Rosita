using Rosita.Infrastructure.Database.Contexts;
using Rosita.XCutting.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rosita.Invoice.Core.Tests.Helpers
{
    public class InvoiceFakeData
    {
        public async Task GenerateAFullInvoiceInDataBaseWithCode(string code)
        {
            Guid ClientId = Guid.NewGuid();
            Guid InvoiceId = Guid.NewGuid();
            Guid InvoiceRecordsId = Guid.NewGuid();
            Guid InvoiceLineId = Guid.NewGuid();
            Guid AddressId = Guid.NewGuid();
            var invoice = new Infrastructure.Database.Entities.Invoice()
            {
                Code = code,
                Id = InvoiceId,
                Amount = 10,
                AmountWithTax = 10 + (10 * 21) / 100,
                ClientId = ClientId
            };
            var invoiceLine = new Infrastructure.Database.Entities.InvoiceLine()
            {
                Id = InvoiceLineId,
                Description = "Thoothpaste",
                InvoiceId = InvoiceId,
                Quantity = 2,
                UnitPrice = 5,
                Tax = 21,
                UnitPriceWithTax = 5 + (5 * 21) / 100,
                TotalLineWithTax = 10 + (10 * 21) / 100
            };
            var invoiceRecord = new Infrastructure.Database.Entities.InvoiceRecord()
            {
                Id = InvoiceRecordsId,
                InvoiceId = InvoiceId,
                Recorded = DateTime.UtcNow,
                WhoHasModified = "Jose"
            };
            var customer = new Infrastructure.Database.Entities.Customer()
            {
                Id = ClientId,
                CanAvoidTax = false,
                LegalDocument = "12345678Z",
                email = "john.doe@something.com",
                Subject = "John Doe"
            };
            var mainAddress = new Infrastructure.Database.Entities.Address()
            {
                Id = AddressId,
                Address1 = "1, Pez Street",
                AddressType = 1, //"MainAddress",
                Description = "Invoice prefered main address",
                City = "Barcelona",
                PostalCode = "08002",
                State = "Catalonia",
                Country = "Spain"
            };
            var dataContext = ServiceLocator.Resolve<DataContext>();
            dataContext.Add(invoice);
            dataContext.Add(invoiceLine);
            dataContext.Add(invoiceRecord);
            dataContext.Add(customer);
            dataContext.Add(mainAddress);
            await dataContext.SaveChangesAsync();
        }
    }
}
