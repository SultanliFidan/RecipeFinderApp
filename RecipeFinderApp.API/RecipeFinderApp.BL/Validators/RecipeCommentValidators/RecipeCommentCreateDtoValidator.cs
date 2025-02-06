using FluentValidation;
using RecipeFinderApp.BL.DTOs.RecipeCommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Validators.RecipeCommentValidators
{
    public class RecipeCommentCreateDtoValidator : AbstractValidator<RecipeCommentCreateDto>
    {
        public RecipeCommentCreateDtoValidator()
        {
            RuleFor(x => x.Comment)
                .NotEmpty()
                .NotNull()
                .WithMessage("Comment cannot be empty")
                .MaximumLength(128)
                .WithMessage("Comment should be less than 128");
        }
    }
}
