using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.MovieApp.Infrastructure.MovieDatasource
{
    /// <summary>
    /// Simulate a 3rd party API for retreiving/creating Movie info
    /// </summary>
    public class MovieDataSource : IMovieDataSource
    {
        public static List<Movie> _movies;

        public MovieDataSource()
        {
            _movies = new List<Movie>()
            {
                new Movie()
                {
                     Id = 1,
                     Title = "Squid Game",
                     YearReleased = "2021",
                     Casts = new List<Cast>()
                     {
                         new Cast(){Name = "Player 001"},
                         new Cast(){Name = "Player 456"},
                         new Cast(){Name = "Police"}
                     }
                },
                new Movie()
                {
                     Id = 2,
                     Title = "Avengers",
                     YearReleased = "2020",
                     Casts = new List<Cast>()
                     {
                         new Cast(){Name = "Robert Downey Jr."},
                         new Cast(){Name = "Tom Holland"},
                         new Cast(){Name = "Scarlet"}
                     }
                },
                new Movie()
                {
                     Id = 3,
                     Title = "Movie 1",
                     YearReleased = "1998",
                     Casts = new List<Cast>()
                     {
                         new Cast(){Name = "Actor 1"},
                         new Cast(){Name = "Actor 2"}
                     }
                }

            };
        }

        public async Task<IEnumerable<Movie>> GetAllDataAsync()
        {
            return _movies;
        }

        public async Task<Movie> GetDataByIdAsync(int id)
        {
            return _movies.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Movie> Create(Movie movie)
        {
            var index = _movies.Count;
            movie.Id = ++index;

            _movies.Add(movie);
            return movie;
        }

        public async Task<Movie> Update(Movie movie)
        {
            var index = _movies.FindIndex(x => x.Id == movie.Id);
            if (index != -1)
            {
                var movieToUpdate = _movies.ElementAt(index);
                movieToUpdate.Title = movie.Title;
                movieToUpdate.YearReleased = movie.YearReleased;
                movieToUpdate.Casts = movie.Casts;
            }
           
            return movie;
        }

        
    }
}
