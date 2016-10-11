using Rosita.Core.Framework.Criterias;

namespace Rosita.Core.Framework
{
    public abstract class UseCaseRequestMessage
    {
        public IUseCaseRequestCriteria Criteria { get; set; }

    }
}