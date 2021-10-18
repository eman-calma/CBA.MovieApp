using CBA.MovieApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CBA.MovieApp.Core.Helpers
{
    public interface ISortHelper<T> where T : class
    {
        IEnumerable<T> Process(IQueryable<T> query, SortModel sortItem, Dictionary<string, Expression<Func<T, object>>> columns);
    }
}
