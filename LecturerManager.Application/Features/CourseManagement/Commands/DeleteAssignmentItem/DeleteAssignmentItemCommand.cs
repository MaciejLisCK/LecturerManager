using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.DeleteAssignmentItem;

public record DeleteAssignmentItemCommand(Guid CourseId, Guid AssignmentId, Guid ItemId) : IRequest;
