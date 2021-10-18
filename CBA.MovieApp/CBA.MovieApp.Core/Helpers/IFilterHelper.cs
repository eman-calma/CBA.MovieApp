using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBA.MovieApp.Core.Helpers
{
    public interface IFilterHelper
    {
        IEnumerable<Movie> Process(IEnumerable<Movie> query, string filterCriteria);
    }
}
