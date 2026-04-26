using LecturerManager.Application.Features.CourseManagement.DTOs;
using LecturerManager.Application.Features.CourseManagement.Mappings;
using LecturerManager.Domain.CourseManagement.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Queries.GetCourses;

public class GetCoursesHandler(ICourseRepository courseRepository) : IRequestHandler<GetCoursesQuery, IReadOnlyList<CourseDto>>
{
    public async Task<IReadOnlyList<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetAllAsync(cancellationToken);
        return [.. courses.Select(c => c.ToDto())];
    }

}
