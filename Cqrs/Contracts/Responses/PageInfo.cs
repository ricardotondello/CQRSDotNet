using System.Collections.Generic;

namespace Cqrs.Contracts.Responses
{
    public class PageInfo<T>
    {
        public PageInfo() { }

        public PageInfo(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
