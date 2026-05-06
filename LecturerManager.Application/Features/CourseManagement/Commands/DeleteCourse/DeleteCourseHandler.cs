using LecturerManager.Domain.CourseManagement.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.DeleteCourse;

public class DeleteCourseHandler(ICourseRepository courseRepository) : IRequestHandler<DeleteCourseCommand>
{
    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        await courseRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
