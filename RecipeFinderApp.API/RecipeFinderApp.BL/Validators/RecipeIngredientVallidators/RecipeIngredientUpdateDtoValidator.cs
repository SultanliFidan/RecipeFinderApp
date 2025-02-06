using FluentValidation;
using RecipeFinderApp.BL.DTOs.RecipeIngredientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Validators.RecipeIngredientVallidators
{
    public class RecipeIngredientUpdateDtoValidator : AbstractValidator<RecipeIngredientUpdateDto>
    {
        public RecipeIngredientUpdateDtoValidator()
        {
            RuleFor(x => x.Quantity)
               .NotEmpty()
               .NotNull()
               .WithMessage("Quantity cannot be empty")
               .MaximumLength(128)
               .WithMessage("Quantity should be less than 128");
        }
    }
}
