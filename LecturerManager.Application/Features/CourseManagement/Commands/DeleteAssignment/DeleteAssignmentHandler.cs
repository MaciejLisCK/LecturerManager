using LecturerManager.Domain.CourseManagement.Exceptions;
using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Domain.Shared.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.DeleteAssignment;

public class DeleteAssignmentHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteAssignmentCommand>
{
    public async Task Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
        if (course is null)
            throw new CourseNotFoundException(request.CourseId);

        course.RemoveAssignment(request.AssignmentId);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
