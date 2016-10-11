namespace Rosita.Core.Framework
{
    public enum UseCaseResponseStatus : short
    {
        None = 0,
        Found = 1,
        NotFound = 2,
        IncorrectCriteria = 3
    }

    public abstract class UseCaseResponseMessage
    {
        public UseCaseResponseStatus Status { get; }

        protected UseCaseResponseMessage(UseCaseResponseStatus status)
        {
            Status = status;
        }
    }


}