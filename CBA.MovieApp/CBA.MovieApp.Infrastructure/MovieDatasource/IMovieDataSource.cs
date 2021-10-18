using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CBA.MovieApp.Infrastructure.MovieDatasource
{
    public interface IMovieDataSource
    {
        Task<IEnumerable<Movie>> GetAllDataAsync();
        Task<Movie> GetDataByIdAsync(int id);
        Task<Movie> Create(Movie movie);
        Task<Movie> Update(Movie movie);
    }
}
