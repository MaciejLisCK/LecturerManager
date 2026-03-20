namespace LecturerManager.Domain.CourseManagement.ValueObjects;

public record CourseName
{
    public string Value { get; }

    private CourseName() { }

    public CourseName(string value)
    {
        Value = value;
    }
}
