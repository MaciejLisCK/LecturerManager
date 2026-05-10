using LecturerManager.Application.Features.CourseManagement.DTOs;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Queries.GetAssignmentById;

public record GetAssignmentByIdQuery(Guid CourseId, Guid AssignmentId) : IRequest<AssignmentDetailDto?>;
