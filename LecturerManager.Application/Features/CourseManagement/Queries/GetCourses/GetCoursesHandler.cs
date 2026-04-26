using LecturerManager.Domain.CourseManagement.Entities;
using LecturerManager.Domain.CourseManagement.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Queries.GetCourses;

public class GetCoursesHandler(ICourseRepository courseRepository) : IRequestHandler<GetCoursesQuery, IReadOnlyList<Course>>
{
    public async Task<IReadOnlyList<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetAllAsync(cancellationToken);
        return courses;
    }
}
