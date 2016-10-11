using System.Runtime.InteropServices.ComTypes;
using Rosita.Core.Framework;
using Rosita.Core.Framework.Criterias;

namespace Rosita.Invoice.Core.Boundaries.GetInvoice
{
    public class GetInvoiceByCodeRequest:UseCaseRequestMessage
    {
        public string InvoiceCode { get; set; }

        public GetInvoiceByCodeRequest(IUseCaseRequestCriteria criteria)
        {
            this.Criteria = criteria;
        }
    }
}