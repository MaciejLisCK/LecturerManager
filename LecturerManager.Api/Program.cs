using LecturerManager.Application.DependencyInjection;
using LecturerManager.Application.Features.CourseManagement.Queries.GetCourses;
using LecturerManager.Domain.CourseManagement.Exceptions;
using LecturerManager.Domain.Identity.Exceptions;
using LecturerManager.Domain.Shared.Exceptions;
using LecturerManager.Infrastructure.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using FluentValidation;
using LecturerManager.Api.DependencyInjection;
using LecturerManager.Api.Endpoints;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionFeature?.Error;

        context.Response.StatusCode = exception switch
        {
            CourseNotFoundException => StatusCodes.Status404NotFound,
            AssignmentNotFoundException => StatusCodes.Status404NotFound,
            LoginAlreadyExistsException => StatusCodes.Status409Conflict,
            InvalidCredentialsException => StatusCodes.Status401Unauthorized,
            DomainException => StatusCodes.Status400BadRequest,
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(new
        {
            status = context.Response.StatusCode,
            error = exception?.Message
        });
    });
});

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapCourseEndpoints();
app.MapAssignmentEndpoints();
app.MapAuthEndpoints();

app.Run();
