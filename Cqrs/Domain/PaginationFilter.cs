namespace Cqrs.Domain
{
    public class PaginationFilter
    {
        public int PageNumber { get; }
        public int PageSize { get; }

        private PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public static PaginationFilter Create(int pageNumber, int pageSize) => new(pageNumber, pageSize);
    }
}
