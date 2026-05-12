using LecturerManager.Domain.CourseManagement.ValueObjects;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignmentItem;

public record CreateAssignmentItemCommand(
    Guid CourseId,
    Guid AssignmentId,
    AssignmentItemType Type,
    string Name) : IRequest<Guid>;
