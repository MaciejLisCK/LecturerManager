using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.CourseManagement.Exceptions;

public sealed class AssignmentItemNotFoundException : DomainException
{
    public AssignmentItemNotFoundException(Guid itemId)
         : base($"Assignment item with ID '{itemId}' was not found")
    { }
}
