using MediatR;

namespace LecturerManager.Application.CourseManagement.Features.CreateAssignment;

public record CreateAssignmentCommand(Guid CourseId, string Name) : IRequest<Guid>;
