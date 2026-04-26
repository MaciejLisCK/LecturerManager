using LecturerManager.Application.Features.CourseManagement.DTOs;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Queries.GetCourses;

public record GetCoursesQuery() : IRequest<IReadOnlyList<CourseDto>>;