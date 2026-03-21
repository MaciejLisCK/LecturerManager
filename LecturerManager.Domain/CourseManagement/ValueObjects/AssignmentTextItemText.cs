using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.CourseManagement.ValueObjects;

public record AssignmentTextItemText
{
    public const int MaxLength = 50000;

    public string Value { get; }

    private AssignmentTextItemText() { }

    public AssignmentTextItemText(string value)
    {
        DomainArgumentNullException.ThrowIfNull(value);
        var valueTrimmed = value.Trim();
        DomainStringEmptyException.ThrowIfEmpty(valueTrimmed);
        DomainStringLengthExceededException.ThrowIfLengthExceeded(valueTrimmed, MaxLength);

        Value = valueTrimmed;
    }
}