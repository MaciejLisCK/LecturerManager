using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Domain.CourseManagement.ValueObjects;
using LecturerManager.Domain.Shared.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignment;

public class CreateAssignmentHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateAssignmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
    {
        if (request.CourseId == Guid.Empty)
            throw new ArgumentException("CourseId cannot be empty.", nameof(request.CourseId));

        var course = await courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
        
        if (course == null)
            throw new InvalidOperationException($"Course with ID '{request.CourseId}' was not found.");

        var assignmentName = new AssignmentName(request.Name);
        var assignmentId = course.AddAssignment(assignmentName);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return assignmentId;
    }
}