using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cqrs.Contracts.Resquests.Queries
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

        private int PageNumber { get; }
        private int PageSize { get; }

        internal int? GetPageNumber() => PageNumber >= 1 ? PageNumber : null;
        internal int? GetPageSize() => PageSize >= 1 ? PageSize : null;

    }
}
