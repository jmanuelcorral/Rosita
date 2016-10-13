using Polly;

namespace Rosita.Core.Framework.UseCaseHandler
{
    public class UseCaseOptions :IUseCaseOptions
    {
        public string Name { get; }
        public Policy Policy { get;  }
        public UseCaseType Type { get; }
        public string suscriptors { get; }

        public UseCaseOptions(UseCaseType type, string name, Policy policy)
        {
            Name = name;
            Type = type;
            Policy = policy;
        }
    }
}