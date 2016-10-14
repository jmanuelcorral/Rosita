using System.Threading.Tasks;
using FluentAssertions;
using Rosita.Core.Framework.Criterias;
using Rosita.Invoice.Core.Boundaries.GetInvoice;
using SimpleInjector;
using TestStack.BDDfy;
using Xunit;
using Rosita.Core.Framework;
using Rosita.XCutting.DI;
using Rosita.Infrastructure.Database.Contexts;
using Rosita.Invoice.Core.Tests.Helpers;

namespace Rosita.Invoice.Core.Tests
{
    [Story(AsA = "Application user",
        IWant = "To Find an invoice",
        SoThat = "I want to see all the information about that invoice")]
    public class GetInvoiceByInvoiceCodeUseCase:IClassFixture<InvoiceFakeData>
    {
        private GetInvoiceByCodeRequest _request;
        private GetInvoiceByCodeResponse _response;
        private UseCase<GetInvoiceByCodeRequest, GetInvoiceByCodeResponse> _useCase;
        private readonly InvoiceFakeData _fakeDataGeneratorInDb;

        public GetInvoiceByInvoiceCodeUseCase(InvoiceFakeData fakeDataGenerator)
        {
            Composition.Setup(new Container(), Lifestyle.Transient);
            _useCase = ServiceLocator.Resolve<UseCase<GetInvoiceByCodeRequest, GetInvoiceByCodeResponse>>();
            _fakeDataGeneratorInDb = fakeDataGenerator;
        }
        [Fact]
        public void GetUseCaseFound()
        {
            this.Given(x => x.AValidRequestMessageWithValidDbData())
             .When(x => x.IFindThisInvoice())
             .Then(x => x.TheSystemSaysItsFound())
             .BDDfy<GetInvoiceByInvoiceCodeUseCase>();
        }
        [Fact]
        public void GetUseCaseNotFound()
        {
            this.Given(x => x.AValidRequestMessageAboutANotFoundInvoice())
              .When(x => x.IFindThisInvoice())
              .Then(x => x.TheSystemSaysItsNotFound())
              .BDDfy<GetInvoiceByInvoiceCodeUseCase>();
        }
        [Fact]
        public void GetUseCaseInvalidCriteria()
        {
            this.Given(x => x.AnInValidRequestMessageWithIncorrectCriteria())
              .When(x => x.IFindThisInvoice())
              .Then(x => x.TheSystemSaysItsIncorrect())
              .BDDfy<GetInvoiceByInvoiceCodeUseCase>();
        }

        #region Given

        private async Task AValidRequestMessageWithValidDbData()
        {
            await _fakeDataGeneratorInDb.GenerateAFullInvoiceInDataBaseWithCode("1");
            _request = new GetInvoiceByCodeRequest(new SimpleUseCaseRequestCriteria(CriteriaType.Equal)) { InvoiceCode = "1" };
        }
        private void AValidRequestMessageAboutANotFoundInvoice()
        {
            _request = new GetInvoiceByCodeRequest(new SimpleUseCaseRequestCriteria(CriteriaType.Equal)) { InvoiceCode = "5"};
        }

        private void AnInValidRequestMessageWithIncorrectCriteria()
        {
            _request = new GetInvoiceByCodeRequest(new SimpleUseCaseRequestCriteria(CriteriaType.EndsWith)) { InvoiceCode = "5" };
        }
        #endregion
        #region When
        private async Task IFindThisInvoice()
        {
            _response = await _useCase.Handle(_request);
        }
        #endregion
        #region Then

        private void TheSystemSaysItsFound()
        {
            _response.Should().NotBe(null);
            _response.Status.Should().Be(UseCaseResponseStatus.Found);
        }
        private void TheSystemSaysItsNotFound()
        {
            _response.Should().NotBe(null);
            _response.Status.Should().Be(UseCaseResponseStatus.NotFound);
        }

        private void TheSystemSaysItsIncorrect()
        {
            _response.Should().NotBe(null);
            _response.Status.Should().Be(UseCaseResponseStatus.IncorrectCriteria);
        }
        #endregion

    }
}