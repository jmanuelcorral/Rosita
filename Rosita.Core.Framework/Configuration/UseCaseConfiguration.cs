using System.Collections.Generic;

namespace Rosita.Core.Framework.UseCaseHandler
{
    public class UseCaseConfiguration
    {
        private readonly Dictionary<string, IUseCaseOptions> UseCaseOptions = new Dictionary<string, IUseCaseOptions>();

        public void Add(string UseCase, IUseCaseOptions options)
        {
            UseCaseOptions.Add(UseCase, options);
        }

        public IUseCaseOptions GetUseCaseOptions(string useCase)
        {
            return UseCaseOptions[useCase];
        }
    }
}