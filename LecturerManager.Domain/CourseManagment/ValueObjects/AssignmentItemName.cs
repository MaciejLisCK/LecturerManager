namespace LecturerManager.Domain.CourseManagment.ValueObjects;

public record AssignmentItemName
{
    public string Value { get; }

    private AssignmentItemName() { }

    public AssignmentItemName(string value)
    {
        Value = value;
    }
}