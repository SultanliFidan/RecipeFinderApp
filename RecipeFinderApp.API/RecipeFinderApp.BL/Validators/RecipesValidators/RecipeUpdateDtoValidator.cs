using FluentValidation;
using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Validators.RecipesValidators
{
    public class RecipeUpdateDtoValidator : AbstractValidator<RecipeUpdateDto>
    {
        public RecipeUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title cannot be empty")
                .MaximumLength(32)
                .WithMessage("Title should be less than 32");
            RuleFor(x => x.Instruction)
                .NotEmpty()
                .NotNull()
                .WithMessage("Title cannot be empty")
                .MaximumLength(255)
                .WithMessage("Title should be less than 255");
            RuleFor(x => x.ImageUrl)
                .NotNull()
                .NotEmpty()
                .WithMessage("Image cannot be empty")
                .Must(file => file.ContentType.StartsWith("image/"))
                .WithMessage("Only image files are allowed");
        }
    }
}
