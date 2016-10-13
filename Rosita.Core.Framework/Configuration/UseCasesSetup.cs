namespace Rosita.Core.Framework.UseCaseHandler
{
    public class UseCasesSetup:IUseCasesSetup
    {
        private static UseCaseConfiguration _useCaseConfiguration;

        public UseCasesSetup()
        {
            _useCaseConfiguration = new UseCaseConfiguration();
        }
        public IUseCasesSetup AddUseCase(UseCase<UseCaseRequestMessage, UseCaseResponseMessage> useCase, IUseCaseOptions useCaseOptions)
        {
            _useCaseConfiguration.Add(useCase.GetType().FullName, useCaseOptions);
            return this;
        }

        public UseCaseConfiguration GetUseCaseConfiguration()
        {
            return _useCaseConfiguration;
        }

    }
}