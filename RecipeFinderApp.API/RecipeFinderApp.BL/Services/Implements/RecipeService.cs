using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RecipeFinderApp.BL.Constants;
using RecipeFinderApp.BL.DTOs.RecipeCommentDtos;
using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using RecipeFinderApp.BL.DTOs.RecipeRatingDTOs;
using RecipeFinderApp.BL.Exceptioins.Common;
using RecipeFinderApp.BL.Exceptioins.UserException;
using RecipeFinderApp.BL.Extensions;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Enums;
using RecipeFinderApp.Core.Repositories;
using RecipeFinderApp.DAL.Context;
using RecipeFinderApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class RecipeService(IMapper _mapper, IGenericRepository<Recipe> _recipeRepository, 
        IRecipeCommentRepository _comment, IHttpContextAccessor _httpContext, RecipeFinderDbContext _context,IRecipeRatingRepository _rating) : IRecipeService
    {
        public async Task CreateRecipe(RecipeCreateDto dto, string destination)
        {


            string? userId = _httpContext.HttpContext?.User?.Claims
           .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new AuthorizationException("User is not authenticated!");
            Recipe recipe = _mapper.Map<Recipe>(dto);
            recipe.UserId = userId;
            
            if (dto.File != null && dto.File.isValidType("image") && dto.File.isValidSize(400))
            {
                recipe.ImageUrl = await dto.File!.UploadAsync(destination, "images", "recipes");
            } 

            await _recipeRepository.AddAsync(recipe);
            await _recipeRepository.SaveAsync();
        }

        public async Task DeleteRecipe(int id)
        {
            Recipe? recipe = await _context.Recipes.FindAsync(id);
            if (recipe is null) throw new NotFoundException<Recipe>();
            var path = Path.Combine("wwwroot","images","recipes",  recipe.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecipeGetDto>> GetAllRecipe()
        {
           
            var recipes = await _recipeRepository.GetAllAsync(x => new RecipeGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Instruction = x.Instruction,
                ImageUrl = x.ImageUrl,
                PreparationTime = x.PreparationTime,
                RecipeComments = x.RecipeComments.Where(x => x.ParentId == null).Select(x => new RecipeCommentGetDto
                {
                    Comment = x.Comment,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Children = x.Children.Select(x => new RecipeCommentGetDto
                    {
                        Comment = x.Comment,
                        Id = x.Id,
                        ParentId = x.ParentId
                    })
                   
                }).ToList(),
                RecipeRatings = x.RecipeRatings,
                UserId = x.UserId,
                Ingredients = x.RecipeIngredients.Select(x => x.Ingredient.Name).ToList()
            }, false,true,true);

            return recipes;

        }


        public async Task<IEnumerable<RecipeGetDto>> GetAllDeletedRecipe()
        {
            var recipes = await _recipeRepository.GetAllAsync(x => new RecipeGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Instruction = x.Instruction,
                ImageUrl = x.ImageUrl,
                PreparationTime = x.PreparationTime,
                UserId = x.UserId,
                Ingredients = x.RecipeIngredients.Select(ri => ri.Ingredient.Name).ToList(),
                RecipeComments = x.RecipeComments.Where(x => x.ParentId == null).Select(x => new RecipeCommentGetDto
                {
                    Comment = x.Comment,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Children = x.Children.Select(x => new RecipeCommentGetDto
                    {
                        Comment = x.Comment,
                        Id = x.Id,
                        ParentId = x.ParentId
                    })

                }).ToList(),
                RecipeRatings = x.RecipeRatings
            },
        isDeleted: true);

            return recipes;
        }

        public async Task<RecipeGetDto?> GetByIdRecipe(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id, x => new RecipeGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Instruction = x.Instruction,
                ImageUrl = x.ImageUrl,
                PreparationTime = x.PreparationTime,
                UserId = x.UserId,
                RecipeComments = x.RecipeComments.Where(x => x.ParentId == null).Select(x => new RecipeCommentGetDto
                {
                    Comment = x.Comment,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Children = x.Children.Select(x => new RecipeCommentGetDto
                    {
                        Comment = x.Comment,
                        Id = x.Id,
                        ParentId = x.ParentId
                    })

                }).ToList(),
                RecipeRatings = x.RecipeRatings,
                Ingredients = x.RecipeIngredients.Select(x => x.Ingredient.Name).ToList()
            }, false);

            return recipe;
        }

        public async Task RestoreRecipe(int id)
        {
            await _recipeRepository.ReverseSoftDeleteAsync(id);
            await _recipeRepository.SaveAsync();
        }

        public async Task SoftDeleteRecipe(int id)
        {
            await _recipeRepository.SoftDeleteAsync(id);
            await _recipeRepository.SaveAsync();
        }

        public async Task UpdateRecipe(int id,RecipeUpdateDto dto, string uploadPath)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id, false);
            if (recipe == null) throw new NotFoundException<Recipe>();

            _mapper.Map(dto, recipe);

            if (dto.ImageUrl != null && dto.ImageUrl.isValidType("image") && dto.ImageUrl.isValidSize(400))
            {
                string fileName = await dto.ImageUrl.UploadAsync(uploadPath);
                recipe.ImageUrl = Path.Combine("wwwroot", "recipes", fileName);
            }

            await _recipeRepository.SaveAsync();
        }

        public async Task RecipeComment(RecipeCommentCreateDto dto)
        {
            RecipeComment? parent = null;
            if (dto.ParentId.HasValue)
            {
                parent = await _comment.GetByIdAsync(dto.ParentId.Value);
                if (parent is null)
                    throw new NotFoundException<RecipeComment>();
            }
            var entity = _mapper.Map<RecipeComment>(dto);
            entity.UserId = _httpContext.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            entity.RecipeId = parent?.RecipeId ?? dto.RecipeId;
            await _comment.AddAsync(entity);
            await _comment.SaveAsync();
        }

        public async Task Rate(int? recipeId, int rate = 1)
        {
            if (!recipeId.HasValue)
                throw new Exception();

            var userId = _httpContext.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            

            if (!await _context.Recipes.AnyAsync(x => x.Id == recipeId))
                throw new NotFoundException<RecipeRating>();

            var rating = await _context.RecipeRatings
                .Where(x => x.RecipeId == recipeId && x.UserId == userId)
                .FirstOrDefaultAsync();

            if (rating is null)
            {
                await _context.RecipeRatings.AddAsync(new RecipeRating
                {
                    RecipeId = recipeId.Value,
                    RatingRate = rate,
                    UserId = userId
                });
            }
            else
            {
                rating.RatingRate = rate;
            }

            await _rating.SaveAsync(); 
        }

        public async Task<IEnumerable<RecipeGetDto>> GetFilteredRecipe(int? preparationTime,string? ingredient)
        {
            var query = _recipeRepository.GetQuery(x => new RecipeGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Instruction = x.Instruction,
                PreparationTime = x.PreparationTime,
                RecipeRatings = x.RecipeRatings,
                RecipeComments = x.RecipeComments.Where(x => x.ParentId == null).Select(x => new RecipeCommentGetDto
                {
                    Comment = x.Comment,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Children = x.Children.Select(x => new RecipeCommentGetDto
                    {
                        Comment = x.Comment,
                        Id = x.Id,
                        ParentId = x.ParentId
                    })

                }).ToList(),
                ImageUrl = x.ImageUrl,
                UserId = x.UserId,
                
                Ingredients = x.RecipeIngredients.Select(x => x.Ingredient.Name).ToList()

            }, true, false);

            if (preparationTime > 0)
            {
                query = query.Where(x => x.PreparationTime == preparationTime);
            }

            if (!string.IsNullOrWhiteSpace(ingredient))
            {
                query = query.Where(x => x.Ingredients.Any(i => i.Contains(ingredient)));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<RecipeGetDto>> GetSearchedRecipe(string title)
        {
            var query = _recipeRepository.GetQuery(x => new RecipeGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Instruction = x.Instruction,
                PreparationTime = x.PreparationTime,
                RecipeRatings = x.RecipeRatings,
                RecipeComments = x.RecipeComments.Where(x => x.ParentId == null).Select(x => new RecipeCommentGetDto
                {
                    Comment = x.Comment,
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Children = x.Children.Select(x => new RecipeCommentGetDto
                    {
                        Comment = x.Comment,
                        Id = x.Id,
                        ParentId = x.ParentId
                    })

                }).ToList(),
                ImageUrl = x.ImageUrl,
                UserId = x.UserId,

                Ingredients = x.RecipeIngredients.Select(x => x.Ingredient.Name).ToList()

            }, true, false);

            
            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(x => x.Title.Contains(title) || title.Contains(x.Title));
            }

            return await query.ToListAsync();
        }
    }
}
