using LecturerManager.Domain.CourseManagement.Exceptions;
using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Domain.Shared.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.DeleteAssignmentItem;

public class DeleteAssignmentItemHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteAssignmentItemCommand>
{
    public async Task Handle(DeleteAssignmentItemCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
        if (course is null)
            throw new CourseNotFoundException(request.CourseId);

        course.RemoveAssignmentItem(request.AssignmentId, request.ItemId);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
