using LecturerManager.Application.Features.CourseManagement.DTOs;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Queries.GetCourseById;

public record GetCourseByIdQuery(Guid CourseId) : IRequest<CourseDto?>;
