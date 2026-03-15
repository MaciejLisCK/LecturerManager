namespace LecturerManager.Domain.CourseManagment;

public class Course
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = null!;

    private readonly List<Assignment> _assignments = [];
    public IReadOnlyList<Assignment> Assignments { get; }

    private Course()
    {
        Assignments = null!;
    }

    public Course(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Assignments = _assignments.AsReadOnly();
    }
}
