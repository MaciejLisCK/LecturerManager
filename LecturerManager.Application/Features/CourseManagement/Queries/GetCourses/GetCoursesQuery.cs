using LecturerManager.Domain.CourseManagement.Entities;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Queries.GetCourses;

public record GetCoursesQuery() : IRequest<IReadOnlyList<Course>>;