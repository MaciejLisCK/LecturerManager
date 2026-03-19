namespace LecturerManager.Domain.CourseManagment.ValueObjects;

public record AssignmentName
{
    public string Value { get; }

    private AssignmentName() { }

    public AssignmentName(string value)
    {
        Value = value;
    }
}