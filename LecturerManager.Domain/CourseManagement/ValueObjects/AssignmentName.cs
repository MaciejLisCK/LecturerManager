using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.CourseManagement.ValueObjects;

public record AssignmentName
{
    private const int MaxLength = 300;

    public string Value { get; }

    private AssignmentName() { }

    public AssignmentName(string value)
    {
        DomainArgumentNullException.ThrowIfNull(value);
        var valueTrimmed = value.Trim();
        DomainStringEmptyException.ThrowIfEmpty(valueTrimmed);
        DomainStringLengthExceededException.ThrowIfLengthExceeded(valueTrimmed, MaxLength);

        Value = valueTrimmed;
    }
}
