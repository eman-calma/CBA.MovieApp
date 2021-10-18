using CBA.MovieApp.Core.Domain.Movies.Commands;
using CBA.MovieApp.Core.Domain.Movies.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sympli.SearchRank.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBA.MovieApp.Api.Controllers
{
    [Route("api/movie")]
    public class MovieController : BaseController
    {
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Movies([FromBody]GetMoviesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Movie([FromRoute] GetMovieByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Movie([FromBody] AddMovieCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Movie([FromBody] UpdateMovieCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
