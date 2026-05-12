using LecturerManager.Domain.CourseManagement.Exceptions;
using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Domain.CourseManagement.ValueObjects;
using LecturerManager.Domain.Shared.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignmentItem;

public class CreateAssignmentItemHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAssignmentItemCommand, Guid>
{
    public async Task<Guid> Handle(CreateAssignmentItemCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
        if (course is null)
            throw new CourseNotFoundException(request.CourseId);

        var itemId = course.AddAssignmentItem(
            request.AssignmentId,
            new AssignmentItemName(request.Name),
            request.Type);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return itemId;
    }
}
