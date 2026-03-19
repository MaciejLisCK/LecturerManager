namespace LecturerManager.Domain.CourseManagment.ValueObjects;

public record AssignmentTextItemText
{
    public string Value { get; }

    private AssignmentTextItemText() { }

    public AssignmentTextItemText(string value)
    {
        Value = value;
    }
}