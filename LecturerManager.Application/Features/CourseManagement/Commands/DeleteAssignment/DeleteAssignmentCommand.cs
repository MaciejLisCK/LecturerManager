using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.DeleteAssignment;

public record DeleteAssignmentCommand(Guid CourseId, Guid AssignmentId) : IRequest;
