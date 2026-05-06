using LecturerManager.Domain.CourseManagement.Entities;
using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Domain.CourseManagement.ValueObjects;
using LecturerManager.Domain.Shared.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateCourse;

public class CreateCourseHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCourseCommand, Guid>
{
    public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course(new CourseName(request.Name));
        await courseRepository.AddAsync(course, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return course.Id;
    }
}
