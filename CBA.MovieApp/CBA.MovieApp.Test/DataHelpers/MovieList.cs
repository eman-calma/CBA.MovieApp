using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBA.MovieApp.Test.DataHelpers
{
    public static class MovieList
    {
        public static readonly List<Movie> NotSortedByYear = new List<Movie>
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

        public static readonly List<Movie> SortedByYearAscending = new List<Movie>
        {
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
                Id = 1,
                Title = "Squid Game",
                YearReleased = "2021",
                Casts = new List<Cast>()
                {
                    new Cast(){Name = "Player 001"},
                    new Cast(){Name = "Player 456"},
                    new Cast(){Name = "Police"}
                }
            }
        };

        public static readonly List<Movie> SortedByTitleAscending = new List<Movie>
        {
            
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
            },
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
            }
        };

        public static readonly List<Movie> FilteredByTitle = new List<Movie>
        {

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
            }
        };

    }
}
