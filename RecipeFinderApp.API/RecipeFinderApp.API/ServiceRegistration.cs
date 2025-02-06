using RecipeFinderApp.BL.DTOs.Options;

namespace RecipeFinderApp.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Jwt));
            return services;
        }
    }
}
