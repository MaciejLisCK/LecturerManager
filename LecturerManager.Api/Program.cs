using LecturerManager.Application.DependencyInjection;
using LecturerManager.Application.Features.CourseManagement.Queries.GetCourses;
using LecturerManager.Domain.CourseManagement.Exceptions;
using LecturerManager.Domain.Shared.Exceptions;
using LecturerManager.Infrastructure.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using FluentValidation;
using LecturerManager.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
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

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapCourseEndpoints();

app.Run();
