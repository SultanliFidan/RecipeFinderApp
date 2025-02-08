using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RecipeFinderApp.BL.DTOs.Options;
using System.Text;

namespace RecipeFinderApp.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Jwt));
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,IConfiguration Configuration)
        {
            JwtOptions jwtOpt = new JwtOptions();
            jwtOpt.Issuer = Configuration.GetSection("JwtOptions")["Issuer"]!;
            jwtOpt.Audience = Configuration.GetSection("JwtOptions")["Audience"]!;
            jwtOpt.SecretKey = Configuration.GetSection("JwtOptions")["SecretKey"]!;
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpt.SecretKey));
            services.AddAuthentication
                (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = signInKey,
                        ValidAudience = jwtOpt.Audience,
                        ValidIssuer = jwtOpt.Issuer,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            return services;
        }
    }
}
