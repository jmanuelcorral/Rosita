using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rosita.Core.Framework;
using Rosita.Core.Framework.Criterias;
using Rosita.Infrastructure.Database.UnitOfWork;
using Rosita.Invoice.Core.Boundaries.GetInvoice;
using Rosita.XCutting.Mapping;
using Rosita.XCutting.UnitOfWork;

namespace Rosita.Invoice.Core.UseCases
{
    public class GetInvoiceByInvoiceCodeUseCase : UseCase<GetInvoiceByCodeRequest, GetInvoiceByCodeResponse>
    {
        private readonly IBussinessUnitOfWork _unitOfWork;

        public GetInvoiceByInvoiceCodeUseCase(IBussinessUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private bool IsNotSupportedCriteria(CriteriaType type)
        {
            return type != CriteriaType.Equal;
        }

        private List<Expression<Func<Infrastructure.Database.Entities.Invoice, object>>> GetFullInvoiceInclude()
        {
            var args = new List<Expression<Func<Infrastructure.Database.Entities.Invoice, object>>>();
            args.Add(u => u.InvoiceLines);
            args.Add(u => u.Client);
            return args;
        }


        public override async Task<GetInvoiceByCodeResponse> Handle(GetInvoiceByCodeRequest requestMessage)
        {
            if (IsNotSupportedCriteria(requestMessage.Criteria.TypeOfCriteria))
                return new GetInvoiceByCodeResponse(UseCaseResponseStatus.IncorrectCriteria);

            var dbInvoice = await _unitOfWork.InvoiceRepository.GetSingle(x => x.Code == requestMessage.InvoiceCode,
                GetFullInvoiceInclude());
            if (!dbInvoice.HasValue)
                return new GetInvoiceByCodeResponse(UseCaseResponseStatus.NotFound);
            return
                new GetInvoiceByCodeResponse(UseCaseResponseStatus.Found,
                    dbInvoice.Value.MapTo<Entities.FullInvoice, Infrastructure.Database.Entities.Invoice>());
        }

       

    }

}