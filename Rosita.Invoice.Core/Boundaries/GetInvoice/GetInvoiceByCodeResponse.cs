using Rosita.Core.Framework;
using Rosita.Invoice.Core.Entities;

namespace Rosita.Invoice.Core.Boundaries.GetInvoice
{
  
    public class GetInvoiceByCodeResponse:UseCaseResponseMessage
    {
        public FullInvoice Result { get; }

        public GetInvoiceByCodeResponse(UseCaseResponseStatus status, FullInvoice result = null):base(status)
        {
            Result = result;
        }
    }
}