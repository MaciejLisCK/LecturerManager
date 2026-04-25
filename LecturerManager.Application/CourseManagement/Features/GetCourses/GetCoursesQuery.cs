using LecturerManager.Domain.CourseManagement.Entities;
using MediatR;

namespace LecturerManager.Application.CourseManagement.Features.GetCourses;

public record GetCoursesQuery() : IRequest<IReadOnlyList<Course>>;