using System;
using System.Collections.Generic;
using System.Text;

namespace CBA.MovieApp.Common.Models
{
    public class SortModel
    {
        public string SortBy { get; set; }
        public bool IsAscending { get; set; }
        public string SearchCriteria { get; set; }
    }
}
