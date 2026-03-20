using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.CourseManagement.Exceptions;

public sealed class AssignmentNotFoundException : DomainException
{
    public AssignmentNotFoundException(Guid assignmentId)
         : base($"Assignment with ID '{assignmentId}' was not found")
    { }
}
