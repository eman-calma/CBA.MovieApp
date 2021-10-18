using CBA.MovieApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CBA.MovieApp.Core.Helpers
{
    public class SortHelper<T> : ISortHelper<T> where T : class
    {

        public IEnumerable<T> Process(IQueryable<T> query, SortModel sortItem, Dictionary<string, Expression<Func<T, object>>> columns)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sortItem.SortBy) || !columns.ContainsKey(sortItem.SortBy))
                    return query;

                if (sortItem.IsAscending)
                    query = query.OrderBy(columns[sortItem.SortBy]);
                else
                    query = query.OrderByDescending(columns[sortItem.SortBy]);

                return query;
            }
            catch (Exception ex)
            {
                //Implement error logging for future debugging
                return query;
            }
        }
    }
}
