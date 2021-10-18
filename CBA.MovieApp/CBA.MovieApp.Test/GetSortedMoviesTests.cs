using CBA.MovieApp.Common.Models;
using CBA.MovieApp.Core.Domain.Movies.Queries;
using CBA.MovieApp.Core.Helpers;
using CBA.MovieApp.Infrastructure.MovieDatasource.Entities;
using CBA.MovieApp.Test.DataHelpers;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static CBA.MovieApp.Core.Domain.Movies.Queries.GetMoviesCommand;

namespace CBA.MovieApp.Test
{
    public class GetSortedMoviesTests
    {
        private SortHelper<Movie> _sut;

        public GetSortedMoviesTests()
        {
            _sut = new SortHelper<Movie>();
        }

        [Test]
        public void ShouldReturnSortedByYearAscending()
        {
            var sorted = MovieList.SortedByYearAscending;
            var sortItem = new SortModel() { SortBy = "YearReleased", IsAscending = true };
            var columnsMap = new Dictionary<string, Expression<Func<Movie, object>>>()
            {
                ["YearReleased"] = m => m.YearReleased,
                ["Title"] = m => m.Title
            };

            var result = _sut.Process(sorted.AsQueryable(), sortItem, columnsMap);

            Assert.AreEqual(sorted, result);
        }

        [Test]
        public void ShouldReturnSortedByTitleAscending()
        {
            var sorted = MovieList.SortedByTitleAscending;
            var sortItem = new SortModel() { SortBy = "Title", IsAscending = true };
            var columnsMap = new Dictionary<string, Expression<Func<Movie, object>>>()
            {
                ["YearReleased"] = m => m.YearReleased,
                ["Title"] = m => m.Title
            };

            var result = _sut.Process(sorted.AsQueryable(), sortItem, columnsMap);

            Assert.AreEqual(sorted, result);
        }

        [Test]
        public void ShouldReturnFiltered()
        {
            var sorted = MovieList.FilteredByTitle;
            var sortItem = new SortModel() { SortBy = "Title", IsAscending = true, SearchCriteria = "Avengers" };
            var columnsMap = new Dictionary<string, Expression<Func<Movie, object>>>()
            {
                ["YearReleased"] = m => m.YearReleased,
                ["Title"] = m => m.Title
            };

            var result = _sut.Process(sorted.AsQueryable(), sortItem, columnsMap);

            Assert.AreEqual(sorted, result);
        }
    }
}