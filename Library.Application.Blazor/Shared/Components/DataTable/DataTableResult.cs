using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Blazor.Shared.Components.DataTable
{
    public class DataTableResult<T>
    {
        public int CallNumber { get; set; }
        public int MaxItems { get; set; }
        public IList<T> Results { get; set; }

        public DataTableResult() { }

        /// <summary>
        /// Create a new DataTableResult based on the query
        /// </summary>
        /// <param name="callNumber"></param>
        /// <param name="query">IQueryable</param>
        /// <param name="pageNumber">pageNumber zero-index</param>
        /// <param name="pageSize">number of items on a page</param>
        public DataTableResult(int callNumber, IQueryable<T> query, int pageNumber, int pageSize)
        {
            CallNumber = callNumber;

            var start = pageNumber * pageSize;
            var end = start + pageSize;

            MaxItems = query.Count();
            Results = start == end ? Enumerable.Empty<T>().ToArray() : query.Skip(start).Take(end).ToArray();
        }
    }
}
