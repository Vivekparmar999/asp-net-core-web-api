using System;
using System.Collections.Generic;
using System.Linq;

namespace mybooks.Data.Paging
{
    public class PaginatedList<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        //count: Total number of pages
        //PageSize: Number of page in 1 page
        public PaginatedList(List<T> items, int count, int pageIndex , int pageSize)
        {

            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            //TotalPages: Number of pages 1,2,3...

            this.AddRange(items);
        }

        public bool HasPreviousPage {
            get { return PageIndex > 1; }
        }

        public bool HasNextPage 
        {
            get { return PageIndex < TotalPages; }
        }


        public static PaginatedList<T> Create(IQueryable<T> source, int pageNUmber, int pageSize) 
        {
            var count = source.Count();
            //12 items, page Size 5 , we want 2 page
            var items = source.Skip((pageNUmber - 1) * pageSize).Take(pageSize).ToList();
                                    //skip((2-1)*5) skip first 5 items Take second five means 2 age
            return new PaginatedList<T>(items, count, pageNUmber, pageSize);
        }
    }
}
