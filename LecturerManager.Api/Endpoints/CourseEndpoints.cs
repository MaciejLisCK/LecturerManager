using LecturerManager.Application.Features.CourseManagement.Commands.CreateCourse;
using LecturerManager.Application.Features.CourseManagement.Commands.DeleteCourse;
using LecturerManager.Application.Features.CourseManagement.DTOs;
using LecturerManager.Application.Features.CourseManagement.Queries.GetCourseById;
using LecturerManager.Application.Features.CourseManagement.Queries.GetCourses;
using MediatR;

namespace LecturerManager.Api.Endpoints;

public static class CourseEndpoints
{
    public static IEndpointRouteBuilder MapCourseEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/courses", async (ISender sender, CancellationToken cancellationToken) =>
            await sender.Send(new GetCoursesQuery(), cancellationToken)
        )
        .WithName("GetCourses")
        .WithTags("Courses")
        .Produces<IEnumerable<CourseDto>>();

        app.MapGet("/courses/{id:guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var course = await sender.Send(new GetCourseByIdQuery(id), cancellationToken);
            return course is null ? Results.NotFound() : Results.Ok(course);
        })
        .WithName("GetCourseById")
        .WithTags("Courses")
        .Produces<CourseDto>()
        .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/courses", async (CreateCourseCommand command, ISender sender, CancellationToken cancellationToken) =>
        {
            var id = await sender.Send(command, cancellationToken);
            return Results.Created($"/courses/{id}", new { id });
        })
        .WithName("CreateCourse")
        .WithTags("Courses")
        .Produces(StatusCodes.Status201Created);

        app.MapDelete("/courses/{id:guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            await sender.Send(new DeleteCourseCommand(id), cancellationToken);
            return Results.NoContent();
        })
        .WithName("DeleteCourse")
        .WithTags("Courses")
        .Produces(StatusCodes.Status204NoContent);

        return app;
    }
}
