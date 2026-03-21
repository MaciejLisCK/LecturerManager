using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.CourseManagement.ValueObjects;

public record CourseName
{
    private const int MaxLength = 300;

    public string Value { get; }

    private CourseName() { }

    public CourseName(string value)
    {
        DomainArgumentNullException.ThrowIfNull(value);
        var valueTrimmed = value.Trim();
        DomainStringEmptyException.ThrowIfEmpty(valueTrimmed);
        DomainStringLengthExceededException.ThrowIfLengthExceeded(valueTrimmed, MaxLength);

        Value = valueTrimmed;
    }
}
