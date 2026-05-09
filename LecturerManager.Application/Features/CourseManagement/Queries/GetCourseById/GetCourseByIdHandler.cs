using LecturerManager.Application.Features.CourseManagement.DTOs;
using LecturerManager.Application.Features.CourseManagement.Mappings;
using LecturerManager.Domain.CourseManagement.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Queries.GetCourseById;

public class GetCourseByIdHandler(ICourseRepository courseRepository) : IRequestHandler<GetCourseByIdQuery, CourseDto?>
{
    public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
        return course?.ToDto();
    }
}
