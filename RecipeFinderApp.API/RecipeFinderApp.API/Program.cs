
using Microsoft.EntityFrameworkCore;
using RecipeFinderApp.DAL;
using RecipeFinderApp.DAL.Context;

namespace RecipeFinderApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<RecipeFinderDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddRepositories();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
