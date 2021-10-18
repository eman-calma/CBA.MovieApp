using AutoMapper;
using CBA.MovieApp.Common.Models;
using CBA.MovieApp.Infrastructure.MovieDatasource;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBA.MovieApp.Core.Domain.Movies.Queries
{
    public class GetMovieByIdCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetMovieByIdCommand, ResponseModel>
        {
            private IMovieDataSource _movieDataSource;
            private IMapper _mapper;

            public Handler(IMovieDataSource movieDataSource, IMapper mapper)
            {
                _movieDataSource = movieDataSource;
                _mapper = mapper;
            }
            public async Task<ResponseModel> Handle(GetMovieByIdCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var movie = await _movieDataSource.GetDataByIdAsync(request.Id);

                    return new ResponseModel() { Success = true, Message = "", Data = _mapper.Map<MovieModel>(movie) };
                }
                catch (Exception ex)
                {
                    //Implement error logging
                    return ResponseModel.Failed($"An exception was thrown while fetching movie details.{Environment.NewLine}{ex.Message}");
                }
            }
        }
    }
}
