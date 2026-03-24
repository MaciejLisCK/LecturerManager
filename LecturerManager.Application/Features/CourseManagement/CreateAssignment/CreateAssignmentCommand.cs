using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.CreateAssignment;

public record CreateAssignmentCommand(Guid CourseId, string Name) : IRequest<Guid>;
