using System;
using System.Collections.Generic;
using System.Text;

namespace CBA.MovieApp.Common.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string YearReleased { get; set; }
        public IEnumerable<CastModel> Casts { get; set; } 
    }
}
