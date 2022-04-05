using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class PagenatedList<T>:List<T>
    {
        public PagenatedList(List<T> items,int count,int pageIndex,int pageSize)
        {
            this.AddRange(items);
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }

        public bool HasPrev 
        {
            get => PageIndex > 1;
        }

        public bool HasNext 
        {
            get => TotalPages > PageIndex;
        }

        public static PagenatedList<T> Create(IQueryable<T> query, int pageindex, int pageSize)
        {
            var items = query.Skip((pageindex - 1) * pageSize).Take(pageSize).ToList();
            return new PagenatedList<T>(items, query.Count(), pageindex, pageSize);
        }
    }
}
