namespace Rosita.Core.Framework.Criterias
{
    public class PagedUseCaseRequestCriteria : IUseCaseRequestCriteria
    {
        public bool IsPaged { get; }

        public int QuantityOfRecordsPerPage { get; }

        public int PageRequested { get; }

        public CriteriaType TypeOfCriteria { get; }

        public PagedUseCaseRequestCriteria(CriteriaType typeOfCriteria, int quantityOfRecordsPerPage, int pageRequested)
        {
            IsPaged = true;
            TypeOfCriteria = typeOfCriteria;
            QuantityOfRecordsPerPage = quantityOfRecordsPerPage;
            PageRequested = pageRequested;
        }
    }
}