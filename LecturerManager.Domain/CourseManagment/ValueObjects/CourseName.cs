namespace LecturerManager.Domain.CourseManagment.ValueObjects;

public record CourseName
{
    public string Value { get; }

    private CourseName() { }

    public CourseName(string value)
    {
        Value = value;
    }
}
