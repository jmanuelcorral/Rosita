namespace Rosita.Core.Framework.Criterias
{
    public class SimpleUseCaseRequestCriteria: IUseCaseRequestCriteria
    {
        public CriteriaType TypeOfCriteria { get; }

        public SimpleUseCaseRequestCriteria(CriteriaType typeOfCriteria)
        {
            TypeOfCriteria = typeOfCriteria;
        }
    }
}