using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.CourseManagement.ValueObjects;

public record AssignmentItemName
{
    private const int MaxLength = 300;

    public string Value { get; }

    private AssignmentItemName() { }

    public AssignmentItemName(string value)
    {
        DomainArgumentNullException.ThrowIfNull(value);
        var valueTrimmed = value.Trim();
        DomainStringEmptyException.ThrowIfEmpty(valueTrimmed);
        DomainStringLengthExceededException.ThrowIfLengthExceeded(valueTrimmed, MaxLength);

        Value = valueTrimmed;
    }
}