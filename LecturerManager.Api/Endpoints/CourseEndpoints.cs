using LecturerManager.Application.Features.CourseManagement.Queries.GetCourses;
using MediatR;

namespace LecturerManager.Api.Endpoints;

public static class CourseEndpoints
{
    public static IEndpointRouteBuilder MapCourseEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/courses", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var courses = await sender.Send(new GetCoursesQuery(), cancellationToken);
            return courses;
        })
        .WithName("GetCourses");

        return app;
    }
}
