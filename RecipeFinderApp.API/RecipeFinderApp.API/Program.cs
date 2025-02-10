
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RecipeFinderApp.BL;
using RecipeFinderApp.BL.DTOs.Options;
using RecipeFinderApp.BL.Extensions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.DAL;
using RecipeFinderApp.DAL.Context;

namespace RecipeFinderApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });
            builder.Services.AddDbContext<RecipeFinderDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
            });

            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = false;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<RecipeFinderDbContext>();

            builder.Services.AddAuth(builder.Configuration);
            builder.Services.AddJwtOptions(builder.Configuration);
            builder.Services.AddEmailOptions(builder.Configuration);
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddFluentValidation();
            builder.Services.AddAutoMapper();

            


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();
            app.UseUserSeed();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
