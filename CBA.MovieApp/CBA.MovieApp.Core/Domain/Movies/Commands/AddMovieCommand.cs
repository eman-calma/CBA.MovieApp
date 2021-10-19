using AutoMapper;
using CBA.MovieApp.Common.Models;
using CBA.MovieApp.Infrastructure.Cache;
using CBA.MovieApp.Infrastructure.MovieDatasource;
using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CBA.MovieApp.Core.Domain.Movies.Commands
{
    public class AddMovieCommand : IRequest<ResponseModel>
    {
        public string Title { get; set; }
        public string YearReleased { get; set; }
        public IEnumerable<CastModel> Casts { get; set; }

        public class Handler : IRequestHandler<AddMovieCommand, ResponseModel>
        {
            private IMovieDataSource _movieDataSource;
            private ICacheData<IEnumerable<Movie>> _cacheData;
            private IMapper _mapper;
            

            public Handler(IMovieDataSource movieDataSource, ICacheData<IEnumerable<Movie>> cacheData, IMapper mapper)
            {
                _movieDataSource = movieDataSource;
                _cacheData = cacheData;
                _mapper = mapper;
            }
            public async Task<ResponseModel> Handle(AddMovieCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var movie = new Movie()
                    {
                        Title = request.Title,
                        YearReleased = request.YearReleased,
                        Casts = _mapper.Map<List<Cast>>(request.Casts)
                    };

                    var response = await _movieDataSource.Create(movie);

                    return new ResponseModel() { Success = true, Message = "New movie saved.", Data = _mapper.Map<MovieModel>(response) };
                }
                catch (Exception ex)
                {
                    //Implement error logging
                    return ResponseModel.Failed($"An exception was thrown while saving new movie.{Environment.NewLine}{ex.Message}");
                }
                
            }

        }
    }
}
