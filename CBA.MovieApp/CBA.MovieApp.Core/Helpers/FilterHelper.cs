using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBA.MovieApp.Core.Helpers
{
    public class FilterHelper : IFilterHelper
    {
        public IEnumerable<Movie> Process(IEnumerable<Movie> query, string  filterCriteria)
        {
            try
            {
                if (!string.IsNullOrEmpty(filterCriteria))
                {
                    //DateTime dateTime;
                    //if (DateTime.TryParse(filterCriteria, out dateTime))
                    //{
                    //    query = query.Where(x => x.YearReleased.Year == dateTime.Year);
                    //}
                    //else
                    //{
                        query = query.Where(x => x.Title.ToLower().Contains(filterCriteria.ToLower()) || x.YearReleased.ToString() == filterCriteria);
                    //}
                }

                return query;
            }
            catch(Exception ex)
            {
                //Implement error logging
                return query;
            }
            
        }
    }
}
