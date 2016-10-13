namespace Rosita.Core.Framework.UseCaseHandler
{
    public interface IUseCasesSetup
    {
        IUseCasesSetup AddUseCase(UseCase<UseCaseRequestMessage, UseCaseResponseMessage> useCase, IUseCaseOptions useCaseOptions);
    }
}