using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Properties.Service.Infrastructure.Security.Extensions
{
    public static class SecurityExtensions
    {
        public static void AddSecurity(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //options.Authority = "http://localhost:8081/realms/testidp";//local
                options.Authority = "http://keycloak:8080/realms/testidp";//docker
                options.Audience = "Properties.Service";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:8081/realms/testidp", //campo iss del jwt
                    ValidateAudience = true,
                    ValidAudience = "Properties.Service",
                    ValidateLifetime = true

                };
            });
            services.AddSingleton<IClaimsTransformation, RoleClaimsTransformer>();
            services.AddAuthorization();
        }
    }

}
