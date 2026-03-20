namespace LecturerManager.Domain.CourseManagement.ValueObjects;

public record AssignmentItemName
{
    public string Value { get; }

    private AssignmentItemName() { }

    public AssignmentItemName(string value)
    {
        Value = value;
    }
}