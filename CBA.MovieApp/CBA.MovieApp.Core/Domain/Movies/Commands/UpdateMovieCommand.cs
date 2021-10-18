using AutoMapper;
using CBA.MovieApp.Common.Models;
using CBA.MovieApp.Infrastructure.Cache;
using CBA.MovieApp.Infrastructure.MovieDatasource;
using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace CBA.MovieApp.Core.Domain.Movies.Commands
{
    public class UpdateMovieCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string YearReleased { get; set; }
        public IEnumerable<CastModel> Casts { get; set; }

        public class Handler : IRequestHandler<UpdateMovieCommand, ResponseModel>
        {
            private IMovieDataSource _movieDataSource;
            private IMapper _mapper;

            public Handler(IMovieDataSource movieDataSource, 
                IMapper mapper
                )
            {
                _movieDataSource = movieDataSource;
                _mapper = mapper;
            }
            public async Task<ResponseModel> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var movie = new Movie()
                    {
                        Id = request.Id,
                        Title = request.Title,
                        YearReleased = request.YearReleased,
                        Casts = _mapper.Map<List<Cast>>(request.Casts)
                    };

                    var response = await _movieDataSource.Update(movie);

                    return new ResponseModel() { Success = true, Message = "Movie updated.", Data = _mapper.Map<MovieModel>(response) };
                }
                catch (Exception ex)
                {
                    //Implement error logging
                    return ResponseModel.Failed($"An exception was thrown while fetching movies list.{Environment.NewLine}{ex.Message}");
                }
                
            }

        }
    }
}
