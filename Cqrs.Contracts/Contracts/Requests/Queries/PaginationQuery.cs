namespace Cqrs.Contracts.Contracts.Requests.Queries
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PaginationQuery(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int PageNumber { get; }
        public int PageSize { get; }

        public int? GetPageNumber() => PageNumber >= 1 ? PageNumber : null;
        public int? GetPageSize() => PageSize >= 1 ? PageSize : null;

    }
}
