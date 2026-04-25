using LecturerManager.Domain.CourseManagement.Entities;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.GetCourses;

public record GetCoursesQuery() : IRequest<IReadOnlyList<Course>>;