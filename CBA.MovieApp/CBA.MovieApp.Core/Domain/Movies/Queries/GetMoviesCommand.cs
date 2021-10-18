using AutoMapper;
using CBA.MovieApp.Common.Models;
using CBA.MovieApp.Core.Helpers;
using CBA.MovieApp.Infrastructure.Cache;
using CBA.MovieApp.Infrastructure.MovieDatasource;
using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBA.MovieApp.Core.Domain.Movies.Queries
{
    public class GetMoviesCommand : IRequest<ResponseModel>
    {
        public SortModel SortModel { get; set; }
        public class Handler : IRequestHandler<GetMoviesCommand, ResponseModel>
        {
            private IMovieDataSource _movieDataSource;
            private ICacheData<IEnumerable<Movie>> _cacheData;
            private IMapper _mapper;
            private ISortHelper<Movie> _sortHelper;
            private IFilterHelper _filterHelper;

            public Handler(IMovieDataSource movieDataSource, ICacheData<IEnumerable<Movie>> cacheData, IMapper mapper, ISortHelper<Movie> sortHelper, IFilterHelper filterHelper)
            {
                _movieDataSource = movieDataSource;
                _cacheData = cacheData;
                _mapper = mapper;
                _sortHelper = sortHelper;
                _filterHelper = filterHelper;
            }
            public async Task<ResponseModel> Handle(GetMoviesCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    //Implement Cache here
                    var movies = await _cacheData.GetOrCreate($"Movies_{DateTime.Today}", async () => await _movieDataSource.GetAllDataAsync());

                    if (!string.IsNullOrEmpty(request.SortModel.SearchCriteria))
                        movies = _filterHelper.Process(movies, request.SortModel.SearchCriteria);

                    var columnsMap = new Dictionary<string, Expression<Func<Movie, object>>>()
                    {
                        ["YearReleased"] = m => m.YearReleased,
                        ["Title"] = m => m.Title
                    };

                    movies = _sortHelper.Process(movies.AsQueryable(), request.SortModel, columnsMap);

                    return new ResponseModel() { Success = true, Message = "", Data = _mapper.Map<IEnumerable<MovieModel>>(movies) };
                }
                catch(Exception ex)
                {
                    //Implement error logging
                    return ResponseModel.Failed($"An exception was thrown while fetching movies list.{Environment.NewLine}{ex.Message}");
                }
                
            }
            
        }
    }
}
