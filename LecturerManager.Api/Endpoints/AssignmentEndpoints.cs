using LecturerManager.Api.Requests;
using LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignment;
using LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignmentItem;
using LecturerManager.Application.Features.CourseManagement.Commands.DeleteAssignment;
using LecturerManager.Application.Features.CourseManagement.Commands.DeleteAssignmentItem;
using LecturerManager.Application.Features.CourseManagement.DTOs;
using LecturerManager.Application.Features.CourseManagement.Queries.GetAssignmentById;
using MediatR;

namespace LecturerManager.Api.Endpoints;

public static class AssignmentEndpoints
{
    public static IEndpointRouteBuilder MapAssignmentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/courses/{courseId:guid}/assignments/{assignmentId:guid}", async (Guid courseId, Guid assignmentId, ISender sender, CancellationToken cancellationToken) =>
        {
            var assignment = await sender.Send(new GetAssignmentByIdQuery(courseId, assignmentId), cancellationToken);
            return assignment is null ? Results.NotFound() : Results.Ok(assignment);
        })
        .WithName("GetAssignmentById")
        .WithTags("Assignments")
        .Produces<AssignmentDetailDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

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

        app.MapPost("/courses/{courseId:guid}/assignments/{assignmentId:guid}/items", async (Guid courseId, Guid assignmentId, CreateAssignmentItemRequest body, ISender sender, CancellationToken cancellationToken) =>
        {
            var id = await sender.Send(new CreateAssignmentItemCommand(courseId, assignmentId, body.Type, body.Name), cancellationToken);
            return Results.Created($"/courses/{courseId}/assignments/{assignmentId}/items/{id}", new { id });
        })
        .WithName("CreateAssignmentItem")
        .WithTags("Assignments")
        .Produces(StatusCodes.Status201Created);

        app.MapDelete("/courses/{courseId:guid}/assignments/{assignmentId:guid}/items/{itemId:guid}", async (Guid courseId, Guid assignmentId, Guid itemId, ISender sender, CancellationToken cancellationToken) =>
        {
            await sender.Send(new DeleteAssignmentItemCommand(courseId, assignmentId, itemId), cancellationToken);
            return Results.NoContent();
        })
        .WithName("DeleteAssignmentItem")
        .WithTags("Assignments")
        .Produces(StatusCodes.Status204NoContent);

        return app;
    }
}
