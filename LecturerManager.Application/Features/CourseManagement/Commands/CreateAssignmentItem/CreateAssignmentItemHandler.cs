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

        var itemName = new AssignmentItemName(request.Name);

        var itemId = request.Type switch
        {
            AssignmentItemType.Text => course.AddAssignmentTextItem(
                request.AssignmentId,
                itemName,
                new AssignmentTextItemText(request.Text!)),
            AssignmentItemType.Image => course.AddAssignmentImageItem(
                request.AssignmentId,
                itemName,
                new ImageUrl(request.ImageUrl!)),
            _ => throw new ArgumentException($"Unsupported item type: {request.Type}")
        };

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return itemId;
    }
}
