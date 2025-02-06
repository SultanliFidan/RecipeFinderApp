using FluentValidation;
using RecipeFinderApp.BL.DTOs.IngredientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Validators.IngredientValidators
{
    public class IngredientCreateDtoValidator : AbstractValidator<IngredientCreateDto>
    {
        public IngredientCreateDtoValidator()
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
