using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBA.MovieApp.Core.Domain.Movies.Commands.Validators
{
    public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
    {
        public AddMovieCommandValidator()
        {
            RuleFor(x => x.Title).MaximumLength(50).NotEmpty().NotNull();
            RuleFor(x => x.YearReleased).MaximumLength(4).MinimumLength(4).NotEmpty();
        }
    }
}
