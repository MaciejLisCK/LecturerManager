using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignmentItem;

public record CreateAssignmentItemCommand(
    Guid CourseId,
    Guid AssignmentId,
    AssignmentItemType Type,
    string Name,
    string? Text,
    string? ImageUrl) : IRequest<Guid>;
