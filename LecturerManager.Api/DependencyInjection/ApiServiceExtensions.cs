using System.Text;
using LecturerManager.Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LecturerManager.Api.DependencyInjection;

public static class ApiServiceExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>()
            ?? throw new InvalidOperationException("JWT configuration section is missing.");
        if (string.IsNullOrWhiteSpace(jwtOptions.Key))
            throw new InvalidOperationException("JWT signing key is not configured.");
        if (string.IsNullOrWhiteSpace(jwtOptions.Issuer))
            throw new InvalidOperationException("JWT issuer is not configured.");
        if (string.IsNullOrWhiteSpace(jwtOptions.Audience))
            throw new InvalidOperationException("JWT audience is not configured.");

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        services.AddAuthorization();

        return services;
    }
}
