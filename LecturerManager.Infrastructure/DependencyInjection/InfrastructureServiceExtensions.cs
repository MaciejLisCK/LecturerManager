using LecturerManager.Application.Common.Interfaces;
using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Domain.Identity.Interfaces;
using LecturerManager.Domain.Shared.Interfaces;
using LecturerManager.Domain.Submissions.Interfaces;
using LecturerManager.Infrastructure.Persistence;
using LecturerManager.Infrastructure.Persistence.Services;
using LecturerManager.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LecturerManager.Infrastructure.Persistence.Interceptors;

namespace LecturerManager.Infrastructure.DependencyInjection;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");
            
        services.AddScoped<DomainEventPublishingInterceptor>();
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
            options.AddInterceptors(sp.GetRequiredService<DomainEventPublishingInterceptor>());
        });
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ISubmissionRepository, SubmissionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
        services.Configure<JwtOptions>(opts =>
        {
            opts.Key = configuration["Jwt:Key"] ?? string.Empty;
            opts.Issuer = configuration["Jwt:Issuer"] ?? string.Empty;
            opts.Audience = configuration["Jwt:Audience"] ?? string.Empty;
            if (int.TryParse(configuration["Jwt:ExpiresInMinutes"], out var minutes))
                opts.ExpiresInMinutes = minutes;
        });
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}