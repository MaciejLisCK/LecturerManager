using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignment;

public record CreateAssignmentCommand(Guid CourseId, string Name) : IRequest<Guid>;
