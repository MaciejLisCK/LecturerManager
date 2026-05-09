using LecturerManager.Domain.CourseManagement.Exceptions;
using LecturerManager.Domain.CourseManagement.Interfaces;
using LecturerManager.Domain.CourseManagement.ValueObjects;
using LecturerManager.Domain.Shared.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Commands.CreateAssignment;

public class CreateAssignmentHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateAssignmentCommand, Guid>
{
    public async Task<Guid> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
        if (course is null)
            throw new CourseNotFoundException(request.CourseId);

        var assignmentId = course.AddAssignment(new AssignmentName(request.Name));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return assignmentId;
    }
}