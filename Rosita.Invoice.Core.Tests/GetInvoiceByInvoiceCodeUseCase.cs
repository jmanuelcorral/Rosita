using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rosita.Core.Framework.Criterias;
using Rosita.Invoice.Core.Boundaries.GetInvoice;
using SimpleInjector;
using TestStack.BDDfy;
using Xunit;
using Rosita.Core.Framework;
using Rosita.XCutting.DI;

namespace Rosita.Invoice.Core.Tests
{
    [Story(AsA = "Application user",
        IWant = "To Find an invoice",
        SoThat = "I want to see all the information about that invoice")]
    public class GetInvoiceByInvoiceCodeUseCase
    {
        private GetInvoiceByCodeRequest _notFoundRequest;
        private GetInvoiceByCodeResponse _notFoundResponse;
        private UseCase<GetInvoiceByCodeRequest, GetInvoiceByCodeResponse> _useCase;

        public GetInvoiceByInvoiceCodeUseCase()
        {
            Composition.Setup(new Container(), Lifestyle.Scoped);
            _useCase = ServiceLocator.Resolve<UseCase<GetInvoiceByCodeRequest, GetInvoiceByCodeResponse>>();
        }
        [Fact]
        public void GetUseCaseNotFound()
        {
            this.Given(x => x.AValidRequestMessageAboutANotFoundInvoice())
              .When(x => x.IFindThisInvoice())
              .Then(x => x.TheSystemSaysItsNotFound())
              .BDDfy<GetInvoiceByInvoiceCodeUseCase>();
        }

        private void AValidRequestMessageAboutANotFoundInvoice()
        {
            _notFoundRequest = new GetInvoiceByCodeRequest(new SimpleUseCaseRequestCriteria(CriteriaType.Equal)) { InvoiceCode = "5"};
        }

        private async Task IFindThisInvoice()
        {
            _notFoundResponse = await _useCase.Handle(_notFoundRequest);
        }

        private void TheSystemSaysItsNotFound()
        {
            _notFoundResponse.Should().NotBe(null);
            _notFoundResponse.Status.Should().Be(UseCaseResponseStatus.NotFound);
        }

    }
}