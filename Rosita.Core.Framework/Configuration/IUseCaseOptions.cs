using Polly;

namespace Rosita.Core.Framework.UseCaseHandler
{
    public interface IUseCaseOptions
    {
        string Name { get; }
        Policy Policy { get;  }
        UseCaseType Type { get;  }
        string suscriptors { get;}
    }
}