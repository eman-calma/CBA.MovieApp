using AutoMapper;
using CBA.MovieApp.Common.Models;
using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBA.MovieApp.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieModel, Movie>().ReverseMap();
            CreateMap<CastModel, Cast>().ReverseMap();
            CreateMap<IEnumerable<MovieModel>, IEnumerable<Movie>>();
        }
    }
}
