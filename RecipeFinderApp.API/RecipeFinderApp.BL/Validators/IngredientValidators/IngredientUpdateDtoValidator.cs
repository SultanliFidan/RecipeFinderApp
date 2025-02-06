using FluentValidation;
using RecipeFinderApp.BL.DTOs.IngredientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Validators.IngredientValidators
{
    public class IngredientUpdateDtoValidator : AbstractValidator<IngredientUpdateDto>
    {
        public IngredientUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be empty")
                .MaximumLength(32)
                .WithMessage("Name should be less than 32");
        }
    }
}
