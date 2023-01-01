using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BookService.QueryObjects
{
    public static class Pagger
    {
        public static IQueryable<T> Page <T>(this IQueryable<T>query , int pageNumZeroStart, int pageSize)
        {
            if (pageSize == 0)
                throw new ArgumentOutOfRangeException
                (nameof(pageSize), "pageSize cannot be zero.");
            if (pageNumZeroStart != 0)
                query = query
                .Skip(pageNumZeroStart * pageSize);
            return query.Take(pageSize);
        }
    }
}
