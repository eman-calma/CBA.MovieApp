using System;
using System.Collections.Generic;
using System.Text;

namespace CBA.MovieApp.Infrastructure.MovieDatasource.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string YearReleased { get; set; }
        public IEnumerable<Cast> Casts { get; set; }
    }
}
