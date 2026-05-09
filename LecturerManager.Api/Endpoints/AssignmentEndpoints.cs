using LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignment;
using LecturerManager.Application.Features.CourseManagement.Commands.DeleteAssignment;
using MediatR;

namespace LecturerManager.Api.Endpoints;

public static class AssignmentEndpoints
{
    public static IEndpointRouteBuilder MapAssignmentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/courses/{courseId:guid}/assignments", async (Guid courseId, CreateAssignmentRequest body, ISender sender, CancellationToken cancellationToken) =>
        {
            var id = await sender.Send(new CreateAssignmentCommand(courseId, body.Name), cancellationToken);
            return Results.Created($"/courses/{courseId}/assignments/{id}", new { id });
        })
        .WithName("CreateAssignment")
        .WithTags("Assignments")
        .Produces(StatusCodes.Status201Created);

        app.MapDelete("/courses/{courseId:guid}/assignments/{assignmentId:guid}", async (Guid courseId, Guid assignmentId, ISender sender, CancellationToken cancellationToken) =>
        {
            await sender.Send(new DeleteAssignmentCommand(courseId, assignmentId), cancellationToken);
            return Results.NoContent();
        })
        .WithName("DeleteAssignment")
        .WithTags("Assignments")
        .Produces(StatusCodes.Status204NoContent);

        return app;
    }
}

public record CreateAssignmentRequest(string Name);
