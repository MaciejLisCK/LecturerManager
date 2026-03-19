namespace LecturerManager.Domain.CourseManagment.ValueObjects;

public record ImageUrl
{
    public string Value { get; }

    private ImageUrl() { }

    public ImageUrl(string value)
    {
        Value = value;
    }
}