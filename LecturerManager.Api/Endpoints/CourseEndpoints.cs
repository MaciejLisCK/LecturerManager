using LecturerManager.Application.Features.CourseManagement.DTOs;
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

        return app;
    }
}
