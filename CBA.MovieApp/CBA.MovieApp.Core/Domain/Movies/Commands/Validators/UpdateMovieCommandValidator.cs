using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBA.MovieApp.Core.Domain.Movies.Commands.Validators
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(50).NotEmpty();
            RuleFor(x => x.YearReleased).MaximumLength(4).MinimumLength(4).NotEmpty();
        }
    }
}
